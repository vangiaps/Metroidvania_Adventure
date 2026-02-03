using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable
{
    public Animator animator;
    public MoveMent moveMent;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private GameObject coinPrefab;
    public float force = 3f;
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
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySfx(AudioManager.Instance.hitSound);

    }
    protected override void Die()
    {
        moveMent.speed = 0;
        boxCollider2D.enabled = false;
        animator.SetTrigger("die");
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySfx(AudioManager.Instance.deadSound);
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        GameObject.Destroy(gameObject, 1f);
    }
}
