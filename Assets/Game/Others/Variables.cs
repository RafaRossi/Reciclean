using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Variables<T> : ScriptableObject
{
    [SerializeField] private T _value;
    public T Value
    {
        get => _value;
        set
        {
            _value = value;

            OnValueChanged();
        }
    }

    public Action OnValueChanged = delegate { };
}
