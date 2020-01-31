using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Droppable : MonoBehaviour, IDropHandler
{
    public Action<PointerEventData> Drop = delegate { };

    public void OnDrop(PointerEventData eventData) => Drop(eventData);
}
