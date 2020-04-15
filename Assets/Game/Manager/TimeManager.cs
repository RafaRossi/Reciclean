using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Manager<TimeManager>
{  
    [SerializeField] private Float _time = null;
    public float Time
    {
        get
        {
            return _time.Value;
        }
        set
        {
            _time.Value = Mathf.Round(value);
        }
    }

    public void StartTimeCount()
    {
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        Time += 1;

        yield return new WaitForSeconds(1f);

        StartCoroutine(UpdateTime());
    }
}