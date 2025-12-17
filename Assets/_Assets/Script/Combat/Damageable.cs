using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public int health = 10;
    public virtual void TakeDamage(int damage)
    {
        this.health -= damage;
        Hit();
        if (health <= 0) Die();
    }
    protected virtual void Hit() { }
    protected virtual void Die() { }
}
