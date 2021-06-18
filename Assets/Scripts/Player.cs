using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        Flip();
        Jump();
        CheckingGround();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        //rb.AddForce(moveVector * speed);
    }
    void Flip()
    {
        if (moveVector.x > 0)
        {
            this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if (moveVector.x < 0)
        {
            this.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }
    }

    public float jumpForce = 210f;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
            
    }
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }
}
