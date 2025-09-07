using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damageable
{
    public Animator animator;
    public Move move;
    [SerializeField] private int _health = 5;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        move = GetComponent<Move>();
    }
    private void Start()
    {
        health = this._health;
    }
    protected override void Hit()
    {
        animator.SetTrigger("Hit");
    }
    protected override void Die()
    {
        move.speed = 0;
        animator.SetTrigger("Die");
        GameObject.Destroy(gameObject, 1f);
    }
}
