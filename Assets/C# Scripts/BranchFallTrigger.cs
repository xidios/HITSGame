using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchFallTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float delayBeforeFall = 7f;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            print("Branch is falling");

            Invoke("Fall", delayBeforeFall);
            //Destroy(gameObject, 5f);
        }
    }
    private void Fall()
    {
        rb.isKinematic = false;
    }
}
