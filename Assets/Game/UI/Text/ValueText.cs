using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class ValueText<T> : MonoBehaviour
{
    [SerializeField] protected T value;
    protected TMP_Text text;

    protected virtual void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    protected abstract void UpdateText();
}
