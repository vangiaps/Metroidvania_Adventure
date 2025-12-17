using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject checkPoint;
    public GameObject player;

    private void Awake()
    {
        checkPoint = GameObject.FindGameObjectWithTag("CheckPoint");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDamageReceiver playerDamageReceiver = collision.gameObject.GetComponent<PlayerDamageReceiver>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = checkPoint.transform.position;
            playerDamageReceiver.OnHit(1);
        }
    }
}
