using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public int numberOfCoinsToUnlock = 3;
    public int currentCoins = 0;
    public Animator animator;
    private bool isOpen = false;
    public string scene;

    public DoorTextDisplay doorUI;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (doorUI != null)
            doorUI.scoreText.text = $"0 / {numberOfCoinsToUnlock}";
    }
    private void Update()
    {
        if (currentCoins >= numberOfCoinsToUnlock && !isOpen)
        {
            animator.SetTrigger("unlock");
            isOpen = true;
        }
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
            if (isOpen)
                gameManager.LoadScene(scene);
        }
    }
}
