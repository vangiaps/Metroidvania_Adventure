using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
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
        // 1. TÌM CAMERA VÀ BẮT NÓ THEO DÕI MÌNH
        SetupCamera();

        // 2. ĐẶT LẠI VỊ TRÍ (Quan trọng! Xem giải thích bên dưới)
        MoveToSpawnPoint();
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
    }
}
