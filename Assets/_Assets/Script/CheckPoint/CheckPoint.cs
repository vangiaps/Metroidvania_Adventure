using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private RespawnPoint respawnPoint;
    public BoxCollider2D collider2D;

    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnPoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            respawnPoint.checkPoint = this.gameObject;
            collider2D.enabled = false;
        }
    }
}

