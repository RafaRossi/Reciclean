using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public int levelNum = 0;
    public int starsToUnlock = 0;
    public float timeToEarnStar = Mathf.Infinity;

    public List<Can> trashCans = new List<Can>();
    public List<TrashAssets> trashes = new List<TrashAssets>();
}

[System.Serializable]
public class LevelInfo
{
    public int levelId;

    public int starCount;

    public bool levelEndedStar;
    public bool timeStar;
    public bool noMissesStar;

    public bool isUnlocked;
}
