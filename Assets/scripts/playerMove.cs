using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    public Animator anim;
    public SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

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
            this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        else if (moveVector.x < 0) {
            this.transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
    }

    public float jumpForce = 210f;
    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 60;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (onGround)
            {
                jumpControl = true;
            }
            
        }
        else
        {
            jumpControl = false;
        }
        if (jumpControl)
        {
            if (jumpIteration++ < jumpValueIteration)
            {
                rb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else
        {
            jumpIteration = 0;
        }
        /*if (Input.GetKeyDown(KeyCode.UpArrow)&&onGround) {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.AddForce(Vector2.up * jumpForce);
        }*/
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
