using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    public Animator anim;
    public AudioSource footsteps;
    public GameMaster gm;
    public float timeInJump = 0f;
    public AudioSource jumpLand;
    public PlayerPos playerPos;
    public float ySpeed = 0;
    public float speedUnderDead = -15f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        ySpeed = rb.velocity.y;
        walk();
        Flip();
        Jump();
        CheckingGround();
        CheckingLiane();           
        LianesMechanics();
        LianeUpDown();
        Respawn();
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
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.Space))&& onGround)
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
        DeathByHeight();


    }


    public float CheckRadiusLiane = 0.04f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(CheckLiane.position, CheckRadiusLiane);
    }
    public Transform CheckLiane;
    public bool checkedLiane;
    public LayerMask LianeMask;
    void CheckingLiane() {
        checkedLiane = Physics2D.OverlapPoint(CheckLiane.position, LianeMask);
        anim.SetBool("onLiane", checkedLiane);
    }

    public float LianeSpeed = 1.5f;
    void LianesMechanics()
    {
        if (checkedLiane)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(rb.velocity.x, moveVector.y);
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void LianeUpDown()
    {
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("moveY", moveVector.y);
    }
    void DeathByHeight()
    {
        if (ySpeed < speedUnderDead && onGround)
        {
            gm.PerelomKosteySound();
            playerPos.Respawn();
            
        }
    }


    public void FootStepPlay()
    {
        footsteps.Play();
    }

    public void JumpLandSound()
    {
        jumpLand.Play();
    }
    public void Respawn()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerPos.Respawn();
        }
    }
}
