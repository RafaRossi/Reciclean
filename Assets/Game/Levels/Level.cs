using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public int levelNum = 0;
    public int starsToUnlock = 0;
    public float timeToEarnStar = Mathf.Infinity;
    public bool isComplete = false;

    public LevelInfo info = new LevelInfo();

    public List<Can> trashCans = new List<Can>();
    public List<TrashAssets> trashes = new List<TrashAssets>();

    public bool UnlockLevel(int starCount)
    {
        Level previousLevel = PersistentData.GetLevel(levelNum - 1);

        return starCount >= starsToUnlock && (previousLevel == null || previousLevel.isComplete);
    }
}

[System.Serializable]
public class LevelInfo
{
    public int starCount;

    public bool levelEndedStar;
    public bool timeStar;
    public bool noMissesStar;
}
