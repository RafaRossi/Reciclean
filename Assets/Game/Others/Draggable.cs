using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<PointerEventData> OnDragBegin = delegate { };
    public Action<PointerEventData> Drag = delegate { };
    public Action<PointerEventData> OnDragEnd = delegate { };

    public void OnBeginDrag(PointerEventData eventData) => OnDragBegin(eventData);
    public void OnDrag(PointerEventData eventData) => Drag(eventData);
    public void OnEndDrag(PointerEventData eventData) => OnDragEnd(eventData);
}
