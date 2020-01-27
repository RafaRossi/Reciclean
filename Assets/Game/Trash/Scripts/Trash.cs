using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{
    private TrashAssets trashItem;
    private GameManager gameManager;
    private AudioManager audioManager;

    public Rigidbody2D Rigidbody { get; private set; }

    private TrashCan trashCan;

    private void Start()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;
        Rigidbody = GetComponent<Rigidbody2D>();

        Player.Instance.OnFingerUp += FingerUp;
    }

    /*private void OnDisable()
    {
        Player.Instance.OnFingerUp -= FingerUp;
    }*/

    public void FingerUp()
    {
        if(trashCan != null)
        {
            if (CheckTrashCan(trashCan))
            {
                gameManager.SetTrash(1);

                gameManager.OnPlayerScore.Invoke();

                //AudioClip clip = gameManager.hits[Random.Range(0, gameManager.hits.Count)];
                //audioManager.PlayEffect(clip);
                //audioManager.PlayEffect(audioManager.hitsEffect);
            }
            else
            {
                gameManager.Misses += 1;

                //AudioClip clip = gameManager.misses[Random.Range(0, gameManager.misses.Count)];
                //audioManager.PlayEffect(clip);
                //audioManager.PlayEffect(audioManager.errorEffect);
            }
        }
        trashCan = null;
        gameManager.ResetPosition();
    }

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

    public bool CheckTrashCan(TrashCan trashCan)
    {
        return trashCan.GetTrashType() == trashItem.trash;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trashCan = collision.gameObject.GetComponent<TrashCan>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TrashCan>())
            trashCan = null;
    }
}
