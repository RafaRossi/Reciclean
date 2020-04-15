using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : BaseLevel
{
    public float timeToEarnStar = Mathf.Infinity;

    public override int EarnStars()
    {
        int starsToEarn = 0;

        if(GameManager.Instance.Misses <= 0) starsToEarn += 1;

        if(TimeManager.Instance.Time < timeToEarnStar) starsToEarn += 1;
        
        starsToEarn += 1;

        if(starsToEarn >= starsScored)
        {
            starsScored = starsToEarn;
        }

        return starsScored;
    }

    public override void InitializeLevel()
    {
        
    }

    public override void ResetLevel()
    {
        base.ResetLevel();

        timeToEarnStar = Mathf.Infinity;
    }
}