using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float acceleration;

    Animator anim;
    Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    Vector2 targetVelocity; //Speed I want to move the player
    Vector2 dampVelocity;//var. where I'm going to save the current speed of the player
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        TargetVelocity();
        Animating();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, targetVelocity, ref dampVelocity, acceleration);
        Debug.Log("velocity = " + dampVelocity);
    }
    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    void TargetVelocity()
    {
        targetVelocity = new Vector2(horizontal * speed, rb2D.velocity.y);
    }
    void Animating()
    {
        if (horizontal != 0) anim.SetBool("IsRunning", true);
        else anim.SetBool("IsRunning", false);
    }
}
