using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardLevel : LevelManager<StandardLevel>
{
    private Trash _trash = null;
    public Trash Trash
    {
        get
        {
            if(!_trash)
                _trash = FindObjectOfType<Trash>();

            return _trash;
        }
        set
        {
            _trash = value;
            _trash.HideTrashName();
        }
    }
    private int currentTrashIndex = 0;

    public void SetTrash(int i)
    {
        currentTrashIndex += i;

        if(currentTrashIndex < Level.trashes.Count)
        {
            Trash.TrashItem = Level.trashes[currentTrashIndex];
        }
        else
        {
            Level.isComplete = true;
            OnLevelEnded.Invoke();
        }
    }
}
