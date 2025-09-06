using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public int health = 10;
    public virtual void TakeDamage(int damage)
    {
        this.health -= damage;
        Debug.Log(transform.name + " : " + health);
        Hit();
        if (health <= 0) Die();
    }
    protected virtual void Hit() { }
    protected abstract void Die();
}
