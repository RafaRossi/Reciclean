using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public List<LevelSlot> slots = new List<LevelSlot>();
    public List<Level> levels = new List<Level>();

    public int totalStars = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].level = this.levels[i];
        }

        List<LevelInfo> levels = new List<LevelInfo>();

        if (PersistentData.Instance.Load())
        {
            levels = PersistentData.Instance.levels;
        }
        else
        {
            PersistentData.Instance.Save();
            levels = PersistentData.Instance.levels;
        }
        foreach (LevelInfo level in levels)
        {
            totalStars += level.starCount;
        }

        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].isUnlocked = (totalStars >= this.levels[i].starsToUnlock);
            slots[i].SetLevelInfo(levels[i]);
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
