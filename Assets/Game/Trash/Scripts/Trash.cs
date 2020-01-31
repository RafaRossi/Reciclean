using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Trash : MonoBehaviour
{
    private TrashAssets trashItem;
    public TrashAssets TrashItem
    {
        get
        {
            return trashItem;
        }
        set
        {
            trashItem = value;

            if(trashItem.sprite != null)
                gameObject.GetComponent<Image>().sprite = trashItem.sprite;
        }
    }

    [SerializeField] private CanvasGroup canvasGroup = null;

    private Vector3 trashHolderPosition;

    private void Start()
    {
        trashHolderPosition = transform.position;
        
        Draggable draggable = GetComponent<Draggable>();

        draggable.OnDragBegin += (e) => {
            canvasGroup.blocksRaycasts = false;
        };

        draggable.Drag += MoveTrash;

        draggable.OnDragEnd += (e) =>{
            ResetPosition();
            canvasGroup.blocksRaycasts = true;
        };
    }

    private void MoveTrash(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    private void ResetPosition()
    {
        transform.position = trashHolderPosition;
    }
}
