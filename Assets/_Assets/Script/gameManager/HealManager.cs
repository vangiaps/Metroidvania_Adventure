using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealManager : Damageable
{
    [Header("References")]
    public static HealManager Instance;


    [SerializeField] private int _defaultMaxHealth = 6;
    [SerializeField] public HealthDisplay healthDisplay;

    public bool isDie = false;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
        healthDisplay.UpdateHp(health);
    }
    protected override void Die()
    {
        isDie = true;
    }
}
