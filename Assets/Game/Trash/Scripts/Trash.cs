using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Trash : MonoBehaviour
{
    protected TrashAssets trashItem;
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

    [SerializeField] protected CanvasGroup canvasGroup = null;

    [SerializeField] protected Transform trashHolder;

    protected bool isBeingDragged;

    protected virtual void Initialize()
    {
        SetHolderPosition();
    }

    private void Start()
    {
        Initialize();

        Draggable draggable = GetComponent<Draggable>();

        draggable.OnDragBegin += (e) => {
            canvasGroup.blocksRaycasts = false;
            isBeingDragged = true;
        };

        draggable.Drag += Drag;

        draggable.OnDragEnd += (e) =>{        
            canvasGroup.blocksRaycasts = true;
            isBeingDragged = false;
            ResetPosition();
        };
    }

    private void Drag(PointerEventData eventData)
    {
        MoveTrash(eventData.position);
    }

    protected virtual void MoveTrash(Vector3 direction)
    {
        transform.position = direction;
    }

    protected virtual void ResetPosition()
    {
        MoveTrash(trashHolder.position);
    }

    private void SetHolderPosition()
    {
        if(trashHolder)
            trashHolder.position = transform.position;
    }

    public void ShowTrashName()
    {
        GameManager.Instance.trashName.ShowTrashName(trashItem);
    }

    public void HideTrashName()
    {
        GameManager.Instance.trashName.HideTrashName();
    }
}
