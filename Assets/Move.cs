using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    //private RigidBody selfRigidbody;

    public float JumpForce = 5.0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    //  ##  ##  ##  ##  ##  ##  ## //
    void Update()
    {

        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        if (Input.GetKeyDown("space"))
            Jump();
        // Rotate around our y-axis (usar apenas para 3D)
        //float rotation = Input.GetAxis("Vertical") * rotationSpeed;
        //rotation *= Time.deltaTime;
        // transform.Rotate(0, rotation, 0);
    }

    void Jump()
    {
        if (CanJump())
        {
            // Jump on ridigbody
            rb.AddForce(0, JumpForce,0, ForceMode.Impulse); //(jumpStrength * transform.up, ForceMode.Impulse);
        }
    }
    bool CanJump()
    {
        // Create Ray
        Ray ray = new Ray(transform.position, transform.up * -1);

        // Create Hit Info
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, transform.localScale.y + 0.1f))
        {
            return true;
        }

        // Nothing so return false
        return false;
    }
}
