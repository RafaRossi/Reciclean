using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform destroyPoint;

    public Transform trashHolder;

    public float rollerSpeed;

    private RollerTrash _trash;
    public RollerTrash CurrentTrash
    {
        get
        {
            return _trash;
        }
        set
        {
            _trash = value;
            _trash.HideTrashName();
        }
    }

    private void LateUpdate()
    {
        MoveTrashHolder();    
    }

    public void SpawnTrash(RollerTrash trash, TrashAssets asset)
    {
        CurrentTrash = Instantiate(trash, spawnPoint.position, Quaternion.identity, transform);

        CurrentTrash.TrashItem = asset;

        trashHolder.SetPositionAndRotation(spawnPoint.position, Quaternion.identity);
    }

    public void ResetTrash()
    {
        if(CurrentTrash)
            Destroy(CurrentTrash.gameObject);
    }

    public void MoveTrashHolder()
    {
        trashHolder.Translate(Vector3.left * rollerSpeed * Time.deltaTime);

        if (trashHolder.position.x < destroyPoint.position.x)
        {
            ResetTrash();

            GameManager.Instance.Misses++;
        }
    }

    public void ShowTrashName()
    {
        if (CurrentTrash) CurrentTrash.ShowTrashName();
    }
}
