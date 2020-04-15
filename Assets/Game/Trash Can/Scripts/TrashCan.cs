using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour
{
    public Can trashCan;

    private void Start() 
    {
        Droppable droppable = GetComponent<Droppable>();

        droppable.Drop += OnDrop;    
    }

    public void Initialize(Can trashCan)
    {
        this.trashCan = trashCan;

        Image image = GetComponent<Image>();

        image.sprite = trashCan.sprite;
    }

    public TrashType GetTrashType()
    {
        return trashCan.type;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Trash trash = eventData.pointerDrag.GetComponent<Trash>();

        if(trash)
        {
            if(CheckTrashCan(trash.TrashItem))
            {
                GameManager.Instance.OnPlayerScore.Invoke();
            }
            else
            {
                GameManager.Instance.Misses += 1;
            }
        }
    }

    public bool CheckTrashCan(TrashAssets trashItem)
    {
        return GetTrashType() == trashItem.trashType;
    }
}
