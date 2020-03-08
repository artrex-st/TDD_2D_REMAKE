using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    //private RigidBody selfRigidbody;

    public float JumpForce = 5.0f;
    public bool IsGround;
    public LayerMask GroundLayer;
    public RaycastHit hit;
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
        //IsGround = Physics.BoxCast(Col.bounds.center, Col.bounds.size, 0f,Quaternion.)


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.5f, GroundLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            IsGround = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 0.6f, Color.red);
            Debug.Log("Did not Hit");
            IsGround = false;
        }
    }
    void Jump()
    {
        if (IsGround)
        {
            // Jump on ridigbody
            rb.AddForce(0, JumpForce,0, ForceMode.Impulse); //(jumpStrength * transform.up, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    // COLIDERS \\
    private void OnCollisionEnter(Collision collision)
    {
        
        print("Entrou");
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.tag);
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        
        //PlayerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void OnCollisionExit(Collision collision)
    {
        print("Saiu");
    }
}



////
/*
 * // Visualize the contact point
 *      foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.tag);
        }
 * 
 * Debug.DrawRay(contact.point, contact.normal, Color.white);
 * 
 * 
 */
