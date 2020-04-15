using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelManager<T> : Manager<T> where T : MonoBehaviour
{
    [Header("Level Property")]
    [SerializeField]protected BaseLevel _level = null;
    protected BaseLevel Level
    {
        get
        {
            if(!PersistentData.levelToLoad)
                PersistentData.levelToLoad = _level;

            return PersistentData.levelToLoad;
        }
    }
    
    [SerializeField] private Integer _levelNum = null;
    public int LevelNum
    {
        get
        {
            return _levelNum.Value;
        }
        set
        {
            _levelNum.Value = value;
        }
    }
    
    [Header("Trash Property")]
    [SerializeField] private TrashCan trashCan = null;
    [SerializeField] private Transform trashCanHolder = null; 

    [Header("Events")]
    public UnityEvent OnLevelStarted;
    public UnityEvent OnLevelEnded;

    protected virtual void Start()
    {
        SetLevel(Level);
    }

    protected virtual void SetLevel(BaseLevel level)
    {
        LevelNum = level.levelNum;

        OnLevelStarted.Invoke();
    }

    public void SetTrashCans()
    {
        foreach (Can can in Level.trashCans)
        {
            Instantiate(trashCan, trashCanHolder).Initialize(can);
        }  
    }

    public void NextLevel()
    {
        if(PersistentData.GetLevel(Level.levelNum + 1, Level.levelType))
        {
            GameManager.Instance.LoadScene(Level.levelType);
        }
        else GameManager.Instance.OnGameOver.Invoke();
    }
}