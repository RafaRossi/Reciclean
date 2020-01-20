using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public List<LevelInfo> levels = new List<LevelInfo>();
    public List<Level> levelAssests = new List<Level>();

    public LevelInfo levelToLoadInfo;

    public Level level;

    public void SetLevelToLoad(Level level)
    {
        this.level = level;
    }

    public void SetLevelInfo(LevelInfo info)
    {
        levelToLoadInfo = info;
    }

    public void Save()
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameData.inf");

        GameData data = new GameData();

        data.levelsData = levels;

        binary.Serialize(file, data);
        file.Close();
    }

    public bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.inf"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.inf", FileMode.Open);

            GameData data = (GameData)binary.Deserialize(file);
            file.Close();

            levels = data.levelsData;
            return true;
        }
        else
            return false;
    }
}

[Serializable]
public class GameData
{
    public List<LevelInfo> levelsData = new List<LevelInfo>();
}
