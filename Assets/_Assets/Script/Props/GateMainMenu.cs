using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMainMenu : MonoBehaviour
{
    public GameObject vCam1;
    public GameObject vCamMainMenu;
    public Transform checkPoint;
    public GameObject player;
    public GameObject canvans;
    public Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        vCam1.SetActive(false);
        canvans.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("unlock");
            StartCoroutine(OpenDelay(1.5f));
        }
    }
    private IEnumerator OpenDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isOpen = true;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isOpen)
            {
                vCam1.SetActive(true);
                vCamMainMenu.SetActive(false);
                player.transform.position = checkPoint.position;
                canvans.SetActive(true);
            }
        }
    }
}
