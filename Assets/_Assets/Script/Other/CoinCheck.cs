using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.coin += 1;
            Destroy(gameObject);
        }
    }
}
