using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance; // Để gọi từ bất kỳ đâu

    [Header("Kéo FadeImage vào đây")]
    public Image fadeImage;

    [Header("Tốc độ mờ/sáng")]
    public float fadeSpeed = 1.5f;

    private void Awake()
    {
        // Setup Singleton cơ bản (Không cho phép nhân bản)
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Các Cánh cửa (Gate) sẽ gọi hàm này
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        // BƯỚC 1: LÀM ĐEN MÀN HÌNH (FADE OUT)
        fadeImage.gameObject.SetActive(true); // Bật ảnh đen lên
        Color c = fadeImage.color;

        // Tăng dần độ đục (Alpha) từ 0 lên 1
        while (c.a < 1f)
        {
            c.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = c;
            yield return null; // Chờ frame tiếp theo
        }

        // BƯỚC 2: LOAD SCENE MỚI NGẦM TRONG LÚC MÀN HÌNH ĐANG ĐEN KỊT
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null; // Đợi cho đến khi load xong 100%
        }

        // --- ĐÂY LÀ ĐOẠN MA THUẬT CHE GIẤU LAG ---
        // Scene mới đã load xong, nhưng ta bắt màn hình đen đợi thêm nửa giây.
        // Lúc này GC.Collect (dọn rác) sẽ chạy và làm giật game ở phía sau màn đen!
        yield return new WaitForSeconds(0.5f);

        // BƯỚC 3: LÀM SÁNG MÀN HÌNH TRỞ LẠI (FADE IN)
        while (c.a > 0f)
        {
            c.a -= Time.deltaTime * fadeSpeed; // Giảm Alpha về 0
            fadeImage.color = c;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false); // Tắt ảnh đen đi
    }
}