using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public BaseLevel Level
    {
        get
        {
            return PersistentData.levelToLoad;
        }
    }

    [Header("Properties")]
    [SerializeField] private Integer _misses = null;
    public int Misses
    {
        get
        {
            return _misses.Value;
        }
        set
        {
            _misses.Value = value;

            OnPlayerMissess.Invoke();
        }
    }
    
    [SerializeField] private TMP_Text nextLevelStarsText = null;

    [Header("Stars")]
    public GameObject starPrefab;
    public Transform starsHolder;

    [Header("Events")] 
    public UnityEvent OnGameOver;
    public UnityEvent OnPlayerScore;
    public UnityEvent OnPlayerMissess;

    [Header("Help")]
    public UnityEvent OnHelpButtonClick;
    public TrashNameText trashName;

    public void GameOver()
    {
        OnGameOver.Invoke();
    }

    public void EarnStars()
    {
        int starsToEarn = Level.EarnStars();

        PersistentData.playerData.UpdateStarAmount();
        ShowStars(starsToEarn);
    }

    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void LoadScene(LevelType level)
    {
        SceneManager.LoadScene(level.levelName);
    }

    private void ShowStars(int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            Instantiate(starPrefab, starsHolder);
        }
    }
    
    public void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    public void HelpButtonClick()
    {
        OnHelpButtonClick.Invoke();
    }

    public void CheckNextLevel(Button button)
    {
        BaseLevel nextLevel = PersistentData.GetLevel(Level.levelNum + 1, Level.levelType);

        bool canPlayNextLevel = PersistentData.SetLevelToLoad(nextLevel);
        button.interactable = canPlayNextLevel;

        if(!canPlayNextLevel)
        {
            nextLevelStarsText.text = "Stars Needed: " + nextLevel.starsToUnlock;
        }     
    }

    public void PlayTrashName()
    {
        //AudioManager.Instance.PlayEffect(Trash.TrashItem.sound);
    }
}
