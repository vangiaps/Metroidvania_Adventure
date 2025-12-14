using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Damageable
{
    [Header("References")]
    public Animator animator;
    public Move move;

    [SerializeField] private int _defaultMaxHealth = 6;
    [SerializeField] HealthDisplay healthDisplay;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        move = GetComponent<Move>();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Hàm này TỰ ĐỘNG chạy ngay khi Scene 2 vừa load xong
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 2. TÌM UI MỚI (Của Scene hiện tại)
        healthDisplay = FindAnyObjectByType<HealthDisplay>();

        if (healthDisplay != null && GameManager.instance != null)
        {
            // 3. Cập nhật lại biến máu (đề phòng bị lỗi)
            health = GameManager.instance.currentHealth;

            // 4. Vẽ lại số tim (Setup) theo Max Health
            healthDisplay.Setup(GameManager.instance.currentHealth);

            // 5. Cập nhật trạng thái tim (Update) theo máu hiện tại
            healthDisplay.UpdateHp(health);
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
