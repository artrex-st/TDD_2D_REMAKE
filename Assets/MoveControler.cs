using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControler : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            if (Input.GetButton("Jump"))//jump base
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else if((characterController.collisionFlags & CollisionFlags.Sides) != 0) 
        {
            if (Input.GetButton("Jump"))//Jump de parede
            {
                moveDirection.y = jumpSpeed;
                moveDirection.x *= -speed / 4;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        if ((characterController.collisionFlags & CollisionFlags.Sides) != 0)
        {
            print("Touching sides!");
        }
    }
}
