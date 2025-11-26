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
    }
    private void Start()
    {
        healthDisplay = FindAnyObjectByType<HealthDisplay>();
        if (GameManager.instance != null)
        {
            // lấy màu từ gamemanager 
            health = GameManager.instance._maxHealth;
            //if (healthDisplay != null)
            //{
            //    healthDisplay.Setup(GameManager.instance._maxHealth);
            //}
        }
        else
        {
            // phòng trường hợp gamemanager không chay
            health = _defaultMaxHealth;
            //if(healthDisplay != null)
            //{
            //    healthDisplay.Setup(_defaultMaxHealth);
            //}
        }
        //UpdateUI();
    }
    private void UpdateUI()
    {
        if (healthDisplay != null)
        {
            healthDisplay.UpdateHp(health);
        }
    }
    protected override void Hit()
    {
        if (GameManager.instance != null)
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
        if(move != null)
        {
        move.speed = 0;
            move.enabled = false;
        }

        var p1Move = GetComponent<Player1_MoveMent>();
        if (p1Move != null) p1Move.enabled = false;
        // am thanh 
        AudioManager.Instance.PlaySfx(AudioManager.Instance.deadSound);
        animator.SetTrigger("Die");
        GameObject.Destroy(gameObject, 1f);
    }
}
