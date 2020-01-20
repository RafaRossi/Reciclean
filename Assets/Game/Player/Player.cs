using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
    }

    public event Action OnFingerUp;
    public event Action OnFingerDown;

    public GameManager game;

    private Trash Trash {get; set;}

    // Start is called before the first frame update
    void OnEnable()
    {
        OnFingerUp += FingerUp;
        OnFingerDown += FingerDown;
    }

    private void Start()
    {
        game = GameManager.Instance;
    }

    private void OnDisable()
    {
        OnFingerUp -= FingerUp;
        OnFingerDown -= FingerDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OnFingerDown();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                OnFingerUp();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && Trash != null)
            {
                Trash.transform.position = GetTouchPosition();
            }
        }
    }

    public void FingerUp()
    {
        Trash = null;
    }

    public void FingerDown()
    {
        Collider2D collider = Physics2D.OverlapPoint(GetTouchPosition());

        if (collider != null)
        {
            Trash trash = collider.gameObject.GetComponent<Trash>();

            if(trash != null)
            {
                Trash = trash;
            }
        }
    }

    public Vector3 GetTouchPosition()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));
        position.z = 0;

        return position;
    }
}
