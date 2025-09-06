using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable
{
    public Animator animator;
    public MoveMent moveMent;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        moveMent = GetComponent<MoveMent>();
    }

    [SerializeField] private int startHealth = 10;

    private void Start()
    {
        health = this.startHealth;
    }
    protected override void Hit()
    {
        animator.SetTrigger("hit");
    }
    protected override void Die()
    {
        moveMent.speed = 0;
        animator.SetTrigger("die");
        GameObject.Destroy(gameObject, 1f);
    }
}
