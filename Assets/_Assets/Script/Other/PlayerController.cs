using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System;
public class PlayerController : MonoBehaviour
{
    private HealthDisplay healthDisplay;

    private void Awake()
    {

    }
    private void OnEnable()
    {
        // Đăng ký sự kiện: "Mỗi khi load scene xong, hãy gọi hàm OnSceneLoaded của tôi"
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Hủy đăng ký khi Player bị hủy (để tránh lỗi bộ nhớ)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Hàm này sẽ TỰ ĐỘNG chạy mỗi khi sang màn mới
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        MoveToSpawnPoint();
        SetupCamera();
        SetupHp();
    }

    private void SetupHp()
    {
        healthDisplay = FindAnyObjectByType<HealthDisplay>();
        if (healthDisplay != null && GameManager.instance != null)
        {
            healthDisplay.Setup(GameManager.instance._maxHealth);

            healthDisplay.UpdateHp(GameManager.instance.currentHealth);
        }
        else
        {
            if (healthDisplay == null) Debug.LogWarning("Sang màn mới nhưng không tìm thấy UI HealthDisplay!");
        }

    }

    void SetupCamera()
    {

        var vCam = FindAnyObjectByType<CinemachineVirtualCamera>();
        if (vCam != null)
        {
            vCam.Follow = this.transform;
            vCam.LookAt = this.transform;
        }
    }

    void MoveToSpawnPoint()
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }
        else
        {
            Debug.Log("khong tim thay spawnPoint");
        }
    }
}
