using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Check_When_Attacking : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(this.damage);
        }
    }
}
