using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Collider2D cd;
    public LayerMask ground;
    public float runSpeed = 30f;
    public float jumpSpeed = 10f;

    private float horizontalSpeed = 0f;
    private float verticalSpeed = 0f;

    
    private void Update()
    {        
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && cd.IsTouchingLayers(ground))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Do domething");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu openMenu = new OpenMenu();
            openMenu.BackToMenu();
        }
    }

    private void Move()
    {
        float xVal = Input.GetAxisRaw("Horizontal");
        horizontalSpeed = xVal * runSpeed;

        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
        if (xVal != 0)
        {
            transform.localScale = new Vector3(xVal, 1, 1);
            animator.SetBool("IsWalking", true);
        }        
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void Jump()
    {       
            verticalSpeed = 1 * jumpSpeed;
            rb.velocity = new Vector2(rb.velocity.x, verticalSpeed);       
    }
    //private void FixedUpdate()
    //{
    //    controller2D.Move(horizontalSpeed * Time.fixedDeltaTime, false, false);
    //}
}
