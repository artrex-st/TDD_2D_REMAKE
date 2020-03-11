using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    public float speed = 10.0f;
    public float JumpForce = 5.0f;
    public LayerMask GroundLayer;
    private bool IsGround,IsMoved,CanMove;
    private Rigidbody2D rb;
    private CapsuleCollider2D BcPlayer;
    private Animator PlayerAnimator;
    private SpriteRenderer PlayerSprite;
    public Vector2 movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BcPlayer = GetComponent<CapsuleCollider2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        GroundLayer = LayerMask.GetMask("Ground");
    }

    //  ##  ##  ##  ##  ##  ##  ## //
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        //transform.Translate(translation, 0);
        
        rb.velocity = new Vector2(translation,rb.velocity.y);
        movimento = rb.velocity;
        if (translation != 0)
        {
            IsMoved = true;
        }
        else
        {
            IsMoved = false;
        }

        if (translation < 0)
            PlayerSprite.flipX=true;
        else
            PlayerSprite.flipX = false;


        PlayerAnimator.SetBool("IsMoved", IsMoved);

        if (Input.GetKeyDown("space"))
            Jump();
    }
    private void FixedUpdate()
    {
        
        if (Physics2D.BoxCast(BcPlayer.bounds.center,BcPlayer.bounds.size,0f,Vector2.down,0.1f,GroundLayer))   
        {
            Debug.DrawRay(transform.position,Vector3.down * 0.1f, Color.green);
            IsGround = true;
            rb.gravityScale = 1;

        }
        else
        {
            Debug.DrawRay(transform.position,Vector3.down * 0.2f, Color.red);
            IsGround = false;
            rb.gravityScale+=0.1f;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {

        }
    }
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
