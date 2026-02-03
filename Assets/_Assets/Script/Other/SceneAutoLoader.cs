using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class SceneAutoLoader
{
    // Mặc định luôn load Scene có Index = 0 trong Build Settings
    // (Tức là Scene đầu tiên trong danh sách)
    const int START_SCENE_INDEX = 0;

    static SceneAutoLoader()
    {
        EditorApplication.playModeStateChanged += LoadStartScene;
    }

    private static void LoadStartScene(PlayModeStateChange state)
    {
        // Khi người dùng vừa bấm nút Play (nhưng game chưa chạy hẳn)
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            // Tự động lưu Scene hiện tại (để tránh mất dữ liệu bạn vừa sửa ở Scene 3)
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }

        // Khi game bắt đầu chạy (Entered Play Mode)
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Kiểm tra xem Scene đang mở có phải là Scene 0 không?
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != START_SCENE_INDEX)
            {
                // Nếu không phải -> Chuyển ngay lập tức về Scene 0
                UnityEngine.SceneManagement.SceneManager.LoadScene(START_SCENE_INDEX);
            }
        }
    }
}