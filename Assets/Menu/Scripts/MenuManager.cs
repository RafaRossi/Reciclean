using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : Manager<MenuManager>
{
    public List<Level> levels = new List<Level>();
    public LevelSlot slot;
    public Transform levelsContentPanel;

    private void Start()
    {
        PersistentData.InitializeDictionary(levels);

        foreach (Level level in this.levels)
        {
            Instantiate(slot, levelsContentPanel).Initialize(level);
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
