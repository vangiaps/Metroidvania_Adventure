using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damageable
{
    public Animator animator;
    public Move move;
    [SerializeField] private int _health = 6;

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
        FindAnyObjectByType<HealthDisplay>().UpdateHp(health);
        AudioManager.Instance.PlaySfx(AudioManager.Instance.hitSound);
    }
    protected override void Die()
    {
        move.speed = 0;
        AudioManager.Instance.PlaySfx(AudioManager.Instance.deadSound);
        animator.SetTrigger("Die");
        GameObject.Destroy(gameObject, 1f);
    }
}
