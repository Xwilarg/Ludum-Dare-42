﻿using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed { set; get; }
    public List<MyCharacter> followers { set; get; }
    public bool isJumping { private set; get; }
    private Vector2 jumpPos;

    public bool didLost { set; private get; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        followers = new List<MyCharacter>();
        isJumping = false;
        speed = 300f;
    }

    private void Update()
    {
        if (didLost)
            return;
        if (isJumping && transform.position.y <= jumpPos.y)
        {
            isJumping = false;
            rb.gravityScale = 0f;
        }
        else if (!isJumping)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpPos = transform.position;
                rb.gravityScale = 1f;
                rb.AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse);
            }
        }
    }
}