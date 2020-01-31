using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    [SerializeField]
    private List<TrashCan> trashCans = new List<TrashCan>();

    public Trash trash;

    [SerializeField] private Text missesText = null;
    [SerializeField] private Text timeText = null;
    [SerializeField] private Text trashNameText = null;
    [SerializeField] private Text levelText = null;

    [SerializeField] private Text nextLevelStarsText = null;

    private Vector3 trashHolderPosition = Vector3.zero;

    public Level level;

    public UnityEvent OnLevelStarted;
    public UnityEvent OnLevelEnded;
    public UnityEvent OnGameOver;

    public UnityEvent OnPlayerScore;
    public UnityEvent OnPlayerMissess;

    public UnityEvent OnHelpButtonClick;

    private int _misses;
    public int Misses
    {
        get
        {
            return _misses;
        }
        set
        {
            _misses = value;

            missesText.text = Misses.ToString();

            OnPlayerMissess.Invoke();
        }
    }

    public GameObject starPrefab;
    public Transform starsHolder;

    private int currentLevelIndex = 0;

    private float _time;
    private float Time
    {
        get
        {
            return _time;
        }
        set
        {
            _time = value;

            timeText.text = Mathf.Round(_time).ToString();
        }
    }

    private void OnEnable()
    {
        foreach (TrashCan trashCan in trashCans)
        {
            trashCan.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        if (PersistentData.levelToLoad != null)
            SetLevel(PersistentData.levelToLoad);
        else
            OnLevelStarted.Invoke();
    }

    private IEnumerator UpdateTime()
    {
        Time += 1;

        yield return new WaitForSeconds(1f);

        StartCoroutine(UpdateTime());
    }

    public void SetLevel(Level level)
    {
        this.level = level;

        levelText.text = "Level " + level.levelNum;

        OnLevelStarted.Invoke();
    }

    public void SetTrashCans()
    {
        for (int i = 0; i < level.trashCans.Count; i++)
        {
            trashCans[i].gameObject.SetActive(true);
            trashCans[i].SetTrashCan(level.trashCans[i]);
        }
    }

    public void SetTrash(int i)
    {
        currentLevelIndex += i;

        trashNameText.text = "";

        if(currentLevelIndex < level.trashes.Count)
        {
            trash.TrashItem = level.trashes[currentLevelIndex];
        }
        else
        {
            level.isComplete = true;
            OnLevelEnded.Invoke();
        }
    }

    public void GameOver()
    {
        OnGameOver.Invoke();
    }

    public void EarnStars()
    {
        //LevelInfo level = PersistentData.levelToLoad.info;

        int starsToEarn = 0;

        if (Misses <= 0)
        {
            //level.noMissesStar = true;
            starsToEarn += 1;
        }

        if(Time < this.level.timeToEarnStar)
        {
            //level.timeStar = true;
            starsToEarn += 1;
        }

        //level.levelEndedStar = true;
        starsToEarn += 1;

        if(starsToEarn >= level.starsScored)
        {
            level.starsScored = starsToEarn;
            //PersistentData.Save();
        }

        PersistentData.playerData.UpdateStarAmount();
        ShowStars(starsToEarn);
    }

    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowTrashName()
    {
        trashNameText.text = trash.TrashItem._name;
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
        UnityEngine.Time.timeScale = pause ? 0 : 1;
    }

    public void HelpButtonClick()
    {
        OnHelpButtonClick.Invoke();
    }

    public void CheckNextLevel(Button button)
    {
        bool canPlayNextLevel = PersistentData.SetLevelToLoad(PersistentData.levels[level.levelNum + 1]);
        button.interactable = canPlayNextLevel;

        if(!canPlayNextLevel)
        {
            nextLevelStarsText.enabled = true;

            nextLevelStarsText.text = "Stars Needed: " + PersistentData.levels[level.levelNum + 1].starsToUnlock;
        }     
    }

    public void NextLevel()
    {
        if(PersistentData.SetLevelToLoad(PersistentData.levels[level.levelNum + 1]))
        {
            LoadScene("Level");
        }
        else OnGameOver.Invoke();
    }

    public void PlayTrashName()
    {
        AudioManager.Instance.PlayEffect(trash.TrashItem.sound);
    }
}
