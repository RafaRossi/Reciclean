using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName ="Player Data")]
public class PlayerData : ScriptableObject
{
    
    public List<Level> levels = new List<Level>();
    public int totalStars;

    public void UpdateStarAmount()
    {
        totalStars = 0;

        foreach (Level level in levels)
        {
            totalStars += level.info.starCount;    
        }
    }
}
