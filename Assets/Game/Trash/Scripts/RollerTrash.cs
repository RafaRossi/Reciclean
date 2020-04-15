using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RollerTrash : Trash
{
    public Roller Roller { get; set; }

    protected override void Initialize()
    {
        Roller = FindObjectOfType<Roller>();

        trashHolder = Roller.trashHolder;
    }

    private void Update()
    {
        if (isBeingDragged) return;

        ResetPosition();
    }
}
