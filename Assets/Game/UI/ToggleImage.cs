using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{
    [SerializeField] private Boolean _property;

    [SerializeField] private Image _toggleImage;
    public Image Image
    {
        get
        {
            if(!_toggleImage)
                _toggleImage = GetComponentInChildren<Image>();

            return _toggleImage;
        }
    }
    
    private void OnEnable()
    {
        _property.OnValueChanged += Toggle;
    }

    private void Start() 
    {
        _property.OnValueChanged();
    }

    private void OnDisable()
    {
        _property.OnValueChanged -= Toggle;
    }

    public void Toggle()
    {
        Image.enabled = !_property.Value;
    }
}
