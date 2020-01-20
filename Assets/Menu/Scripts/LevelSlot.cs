using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlot : MonoBehaviour
{
    public Image[] starsImage = new Image[3];
    public LevelInfo info;

    public Level level;

    public Text text;

    public Button button;

    public void SetLevelInfo(LevelInfo levelInfo)
    {
        info = levelInfo;
        info.levelId = level.levelNum;

        text.text = level.name;

        UpdateSlot();
    }

    private void UpdateSlot()
    {
        foreach (Image image in starsImage)
        {
            image.enabled = false;
        }

        for (int i = 0; i < info.starCount; i++)
        {
            starsImage[i].enabled = true;
        }

        button.interactable = info.isUnlocked;
    }

    public void SetLevel()
    {
        PersistentData.Instance.SetLevelToLoad(level);
        PersistentData.Instance.SetLevelInfo(info);
        MenuManager.Instance.LoadLevel("Level");
    }
}
