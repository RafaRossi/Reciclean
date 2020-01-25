using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour
{
    public Can trashCan;

    private GameManager gameManager;

    public void SetTrashCan(Can trashCan)
    {
        this.trashCan = trashCan;

        Image image = GetComponent<Image>();

        image.material = trashCan.type.material;
    }

    public TrashType GetTrashType()
    {
        return trashCan.type;
    }
}
