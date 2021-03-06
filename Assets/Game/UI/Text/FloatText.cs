﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : ValueText<Float>
{
    protected override void Awake()
    {
        base.Awake();
        
        value.OnValueChanged += UpdateText;
    }

    protected override void UpdateText()
    {
        text.text = value.Value.ToString();
    }
}
