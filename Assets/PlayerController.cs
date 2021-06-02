using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller2D;

    public float runSpeed = 30f;

    private float horizontalSpeed = 0f;

    private void Update()
    {

        horizontalSpeed = Input.GetAxisRaw("Horizontal") * runSpeed;

    }

    private void FixedUpdate()
    {
        controller2D.Move(horizontalSpeed * Time.fixedDeltaTime, false, false);
    }
}
