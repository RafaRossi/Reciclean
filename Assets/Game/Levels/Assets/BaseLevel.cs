using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLevel: ScriptableObject
{
    [Header("Level Info")]
    public int levelNum = 0;
    public LevelType levelType;
    public int starsToUnlock = 0;

    [Header("Player Data")]
    public int starsScored = 0;
    public bool isComplete = false;

    [Header("Level Properties")]
    public Sprite backGroundImage;
    public List<Can> trashCans = new List<Can>();
    public List<TrashAssets> trashes = new List<TrashAssets>();

    public virtual void ResetLevel()
    {
        levelNum = 0;
        starsToUnlock = 0;
        starsScored = 0;
        
        isComplete = false;

        backGroundImage = null;

        trashCans.Clear();
        trashes.Clear();;
    }

    public virtual void ClearLevel()
    {
        starsScored = 0;
        isComplete = false;
    }

    public virtual bool UnlockLevel(int starCount)
    {
        BaseLevel previousLevel = PersistentData.GetLevel(levelNum - 1, levelType);

        return starCount >= starsToUnlock && (previousLevel == null || previousLevel.isComplete);
    }

    public abstract void InitializeLevel();
    
    public abstract int EarnStars();
}
