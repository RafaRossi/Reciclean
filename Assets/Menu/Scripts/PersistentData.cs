using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEditor;

public static class PersistentData
{
    public static List<BaseLevel> levels = new List<BaseLevel>();

    public static BaseLevel levelToLoad;

    public static PlayerData playerData = (PlayerData)AssetDatabase.LoadAssetAtPath("Assets/Game/Player/PlayerData.asset", typeof(PlayerData));

    [RuntimeInitializeOnLoadMethod] public static void InitializeDictionary()
    {
        levels.Clear();

        foreach (Level level in playerData.levels)
        {
            levels.Add(level);
        }

        playerData.UpdateStarAmount();
    }

    public static bool SetLevelToLoad(BaseLevel level)
    {
        if(level.UnlockLevel(playerData.totalStars))
        {
            levelToLoad = level;

            return true;
        }
        return false;          
    }

    public static BaseLevel GetLevel(int levelNum, LevelType levelType)
    {
        foreach (BaseLevel level in levels)
        {
            if(level.levelType == levelType && level.levelNum == levelNum)
            {
                return level;
            }
        }
        return null;
    }

    public static void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameData.inf");

        GameData data = new GameData();

        //data.levelsData = levels;

        binary.Serialize(file, data);
        file.Close();
    }

    public static bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.inf"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.inf", FileMode.Open);

            GameData data = (GameData)binary.Deserialize(file);
            file.Close();

            //levels = data.levelsData;
            return true;
        }
        else
            return false;
    }
}

[Serializable]
public class GameData
{
    public List<Level> levelsData = new List<Level>();
}
