using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashNameText : StringText
{  
    public void ShowTrashName(TrashAssets trash)
    {
        value.Value = trash._name;
    }

    public void HideTrashName()
    {
        value.Value = "";
    }
}
