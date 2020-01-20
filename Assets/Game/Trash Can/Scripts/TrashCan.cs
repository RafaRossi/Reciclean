using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TrashType
{
    Glass, Metal, Plastic, Paper, Organic
}

[System.Serializable]
public class RecicleInfo
{
    public TrashType type;
    public Material material;
}

public class TrashCan : MonoBehaviour
{
    public Can trashCan;

    private GameManager gameManager;

    public void SetTrashCan(Can trashCan)
    {
        this.trashCan = trashCan;

        Image image = GetComponent<Image>();

        image.material = trashCan.info.material;
    }

    public TrashType GetTrashType()
    {
        return trashCan.info.type;
    }
}
