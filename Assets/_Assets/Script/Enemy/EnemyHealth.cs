using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable
{
    public Animator animator;
    public MoveMent moveMent;
    public GameObject cover;
    private BoxCollider2D boxCollider2D;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
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
        boxCollider2D.enabled = false;
        animator.SetTrigger("die");
        GameObject.Destroy(gameObject, 1f);
        GameObject.Destroy(cover, 1.5f);
    }
}
