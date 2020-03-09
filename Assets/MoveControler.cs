using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControler : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f, jumpSpeed = 8.0f, gravity = 20.0f;
    private bool DoubleJump = false, Game2D = true;
    public Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //moveDirection *= speed;
            moveDirection = MoveAxisPlayer();
            if (Input.GetButton("Jump"))//jump base
            {
                moveDirection.y = jumpSpeed;
            }
            DoubleJump = true;
        }
        else if ((characterController.collisionFlags & CollisionFlags.Sides) != 0 & DoubleJump & Input.GetButton("Jump"))
        {
            moveDirection = Vector3.zero;
            moveDirection = MoveAxisPlayer();
            characterController.Move(moveDirection * Time.deltaTime);
            moveDirection.y = jumpSpeed;
            DoubleJump = false;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

    }
    private Vector3 MoveAxisPlayer()
    {
        var AxisPlayer = new Vector3();
        if (Game2D)
            AxisPlayer = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0) * speed;
        else
            AxisPlayer = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        return AxisPlayer;
    }
    void Jump()
    {
        moveDirection.y = jumpSpeed;
    }
}
