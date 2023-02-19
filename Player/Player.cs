using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    
    private Rigidbody2D _rigidbody2D;
    private DialogTrigger _dialogTrigger;
    private Cursor _cursor;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _dialogTrigger = GameObject.Find("DialogManager").GetComponent<DialogTrigger>();
        _cursor = GameObject.FindWithTag("Cursor").GetComponent<Cursor>();

    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
       MovePlayer();
    }

   
    void MovePlayer()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Debug Horizontal") * speed, Input.GetAxis("Debug Vertical") * speed);
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        }
    }

    
}
