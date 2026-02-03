using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealManager : Damageable
{
    [Header("References")]
    public static HealManager Instance;


    [SerializeField] public int _defaultMaxHealth = 6;
    [SerializeField] public HealthDisplay healthDisplay;

    public bool isDie = false;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        health = _defaultMaxHealth;
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

            // 4. Vẽ lại số tim (Setup) theo Max Health
            healthDisplay.Setup(_defaultMaxHealth);

            // 5. Cập nhật trạng thái tim (Update) theo máu hiện tại
            healthDisplay.UpdateHp(health);
        }
    }
    protected override void Hit()
    {
        healthDisplay.UpdateHp(health);
    }
    public void Healing()
    {
        health += 1;
        healthDisplay.UpdateHp(health);
    }
    protected override void Die()
    {
        isDie = true;
    }
}
