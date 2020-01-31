using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    [Header("Level Info")]
    public int levelNum = 0;
    public int starsToUnlock = 0;
    public float timeToEarnStar = Mathf.Infinity;

    [Header("Player Data")]
    public int starsScored = 0;
    public bool isComplete = false;

    public List<Can> trashCans = new List<Can>();
    public List<TrashAssets> trashes = new List<TrashAssets>();

    public void ResetLevel()
    {
        levelNum = 0;
        starsToUnlock = 0;
        starsScored = 0;
        timeToEarnStar = Mathf.Infinity;
        isComplete = false;

        trashCans.Clear();
        trashes.Clear();;
    }

    public void ClearLevel()
    {
        starsScored = 0;
        isComplete = false;
    }

    public bool UnlockLevel(int starCount)
    {
        Level previousLevel = PersistentData.GetLevel(levelNum - 1);

        return starCount >= starsToUnlock && (previousLevel == null || previousLevel.isComplete);
    }
}