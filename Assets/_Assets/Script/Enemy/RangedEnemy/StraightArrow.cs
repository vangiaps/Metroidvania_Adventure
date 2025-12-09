using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightArrow : EnemyAttack
{
    // sau 5s huy neu ko trung 
    private float lifeTime = 5f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(this.damage);
            Destroy(gameObject);
        }
    }
}
