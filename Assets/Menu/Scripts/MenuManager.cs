using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Manager<MenuManager>
{
    public LevelSlot slot;
    public Transform levelsContentPanel;

    private void Start()
    {
        foreach (Level level in PersistentData.playerData.levels)
        {
            Instantiate(slot, levelsContentPanel).Initialize(level);
        }
    }

    public void LoadLevel(LevelType level)
    {
        SceneManager.LoadScene(level.levelName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}