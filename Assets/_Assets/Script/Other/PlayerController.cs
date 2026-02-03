using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System;
public class PlayerController : MonoBehaviour
{
    protected void OnEnable()
    {
        // Đăng ký sự kiện: "Mỗi khi load scene xong, hãy gọi hàm OnSceneLoaded của tôi"
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    protected void OnDisable()
    {
        // Hủy đăng ký khi Player bị hủy (để tránh lỗi bộ nhớ)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Hàm này sẽ TỰ ĐỘNG chạy mỗi khi sang màn mới
    protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DontDestroyOnLoad(gameObject);
        MoveToSpawnPoint();
        SetupCamera();
    }

    protected void SetupCamera()
    {
        Debug.Log("setcam");
        var vCam = FindAnyObjectByType<CinemachineVirtualCamera>();
        if (vCam != null)
        {
            vCam.Follow = this.transform;
            vCam.LookAt = this.transform;
        }
    }

    protected void MoveToSpawnPoint()
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
