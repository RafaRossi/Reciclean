using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringText : ValueText<String>
{
    protected override void Awake()
    {
        base.Awake();
        
        value.OnValueChanged += UpdateText;
    }

    protected override void UpdateText()
    {
        text.text = value.Value;
    }
}
