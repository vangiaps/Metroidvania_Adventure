using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int numberOfCoinsToUnlock = 3;
    public int currentCoins = 0;
    public Animator animator;
    private bool isOpen = false;
    private bool unlocking = false;
    public string scene;
    private bool hasTriggeredTransition = false;

    public DoorTextDisplay doorUI;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (doorUI != null)
            doorUI.scoreText.text = $"0 / {numberOfCoinsToUnlock}";
    }
    private IEnumerator OpenAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isOpen = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.coin > 0)
            {
                currentCoins += GameManager.instance.coin;
                GameManager.instance.coin = 0;
                if (doorUI != null)
                    doorUI.UpdateDoorUI(currentCoins, numberOfCoinsToUnlock);
            }
            if (currentCoins >= numberOfCoinsToUnlock && !isOpen && !unlocking)
            {
                animator.SetTrigger("unlock");
                unlocking = true;
                StartCoroutine(OpenAfterDelay(1f));
            }
            //if (isOpen)
            //    gameManager.LoadScene(scene);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isOpen && !hasTriggeredTransition)
            {
                hasTriggeredTransition = true;
                SceneFader.instance.FadeToScene(scene);
            }
        }
    }
}
