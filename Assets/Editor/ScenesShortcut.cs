using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScenesShortcut : MonoBehaviour
{
    [MenuItem("Scenes/Main Menu", false, 1)]
    public static void LoadMainMenu()
    {
        OpenScene("Assets/Menu/Main Menu.unity");
    }

    [MenuItem("Scenes/Level T1", false, 1)]
    public static void LoadLevelT1()
    {
        OpenScene("Assets/Game/Levels/Standard Level/Level T1.unity");
    }

    [MenuItem("Scenes/Level T2", false, 1)]
    public static void LoadLevelT2()
    {
        OpenScene("Assets/Game/Levels/Roller Level/Level T2.unity");
    }

    private static void OpenScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }
}
