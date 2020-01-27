using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlot : Button
{
    public GameObject starsPrefab;

    public Level level;

    public Text text;

    public GameObject starsHolder;

    public void Initialize(Level level)
    {
        this.level = level;

        text.text = level.name;

        UpdateSlot();
    }

    private void UpdateSlot()
    {
        for (int i = 0; i < level.info.starCount; i++)
        {
            Instantiate(starsPrefab, starsHolder.transform);
        }

        this.interactable = level.UnlockLevel(PersistentData.playerData.totalStars);
    }

    public void SetLevel()
    {
        if(PersistentData.SetLevelToLoad(level))
            MenuManager.Instance.LoadLevel("Level");
    }
}
