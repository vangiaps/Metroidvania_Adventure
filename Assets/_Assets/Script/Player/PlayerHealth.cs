using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damageable
{
    public Animator animator;
    public Move move;
    [SerializeField] private int _defaultMaxHealth = 6;
    [SerializeField] HealthDisplay healthDisplay;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        move = GetComponent<Move>();
        healthDisplay = FindAnyObjectByType<HealthDisplay>();
    }
    private void Start()
    {
        if(GameManager.instance != null)
        {
            // lấy màu từ gamemanager 
        health = GameManager.instance._maxHealth;
        }
        else
        {
            // phòng trường hợp gamemanager không chay
            health = _defaultMaxHealth;
        }
    }
    protected override void Hit()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.currentHealth = health;
        }
        animator.SetTrigger("Hit");
        healthDisplay.UpdateHp(health);
        AudioManager.Instance.PlaySfx(AudioManager.Instance.hitSound);
    }
    protected override void Die()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.currentHealth = 0;
        }
        move.speed = 0;
        AudioManager.Instance.PlaySfx(AudioManager.Instance.deadSound);
        animator.SetTrigger("Die");
        GameObject.Destroy(gameObject, 1f);
    }
}
