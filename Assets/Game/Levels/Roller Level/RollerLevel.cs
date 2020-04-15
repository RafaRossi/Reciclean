using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerLevel : LevelManager<RollerLevel>
{
    public List<TrashAssets> trashes = new List<TrashAssets>();
    public RollerTrash trashPrefab;

    private TrashAssets currentAsset;

    [SerializeField] private Roller _roller;
    public Roller Roller
    {
        get
        {
            if(!_roller)
                _roller = FindObjectOfType<Roller>();

            return _roller;
        }
    }

    protected override void SetLevel(BaseLevel level)
    {
        LevelNum = level.levelNum;

        foreach (TrashAssets trash in Level.trashes)
        {
            trashes.Add(trash);
        }

        OnLevelStarted.Invoke();
    }

    public void Spawn()
    {
        currentAsset = trashes[Random.Range(0, trashes.Count)];

        Roller.SpawnTrash(trashPrefab, currentAsset);
    }

    public void RemoveTrash()
    {
        trashes.Remove(currentAsset);

        CheckNextTrash();
    }

    public void CheckNextTrash()
    {
        if (trashes.Count > 0)
        {
            Spawn();
        }
        else
        {
            Level.isComplete = true;
            OnLevelEnded.Invoke();
        }
    }
}