using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    public float speed = 10.0f;
    public float JumpForce = 5.0f;
    public bool IsGround;
    public LayerMask GroundLayer;
    public RaycastHit hit;
    public Rigidbody2D rb;
    public CapsuleCollider2D BcPlayer;
    public Animator PlayerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BcPlayer = GetComponent<CapsuleCollider2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    //  ##  ##  ##  ##  ##  ##  ## //
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        //transform.Translate(translation, 0);
        rb.velocity = new Vector2(translation,rb.velocity.y);

        if (Input.GetKeyDown("space"))
            Jump();
    }
    private void FixedUpdate()
    {
        
        if (Physics2D.BoxCast(BcPlayer.bounds.center,BcPlayer.bounds.size,0f,Vector2.down,0.1f,GroundLayer))   
        {
            Debug.DrawRay(transform.position,Vector3.down * 0.1f, Color.green);
            IsGround = true;
            print("Grounded");
        }
        else
        {
            Debug.DrawRay(transform.position,Vector3.down * 0.2f, Color.red);
            IsGround = false;
        }
    }
    void Jump()
    {
        if (IsGround)
        {
            // Jump on ridigbody
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse); //(jumpStrength * transform.up, ForceMode.Impulse);
        }
    }
    // COLIDERS \\
    private void OnDrawGizmos()
    {

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
