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
    public BoxCollider BcPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BcPlayer = GetComponent<BoxCollider>();
    }

    //  ##  ##  ##  ##  ##  ##  ## //
    void Update()
    {

        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal") * speed * 10 * Time.deltaTime, 0);
        //Rigidbody= new Vector2(inputDirection.x, bodiPlayer.velocity.y); //
        transform.Translate(translation, 0, 0);
        
        //IsGround = Physics.BoxCast(Col.bounds.center, Col.bounds.size, 0f,Quaternion.)
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
            Jump();
        if (Physics.BoxCast(transform.position, transform.lossyScale, transform.position*5f, out hit,transform.rotation,5f,GroundLayer))   
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            IsGround = true;
        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 0.6f, Color.red);
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
    // COLIDERS \\
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,transform.position*5f); 
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
