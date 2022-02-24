using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WariorController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float dir = 0f;
    private float speed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        dir = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(dir * speed, rb2d.velocity.y);
    }
}
