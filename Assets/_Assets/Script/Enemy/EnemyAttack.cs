using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDamageReceiver playerDamageReceiver = collision.gameObject.GetComponent<PlayerDamageReceiver>();
        if (playerDamageReceiver != null)
        {
            playerDamageReceiver.OnHit(damage);
        }
    }
}
