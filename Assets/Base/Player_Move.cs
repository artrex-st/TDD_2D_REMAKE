using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody2D bodiPlayer;
    private Vector3 positionRight;
    private Vector3 positionLeft;
    //movimento
    public float speed = 50, maxSpeed = 75, speedJump, maxSpeedJump;

    // Start is called before the first frame update
    void Start()
    {
        bodiPlayer = GetComponent<Rigidbody2D>();

        positionRight = transform.localScale; //rotaçao do persona - - Scale-transform
        positionLeft = transform.localScale; //rotaçao do persona
        positionLeft.x *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        Move_Key();
    }

    public void Move_Key()
    {
        // movimento
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal") * speed * 10 * Time.deltaTime, 0);
        /*
        if (hitJumpCont <= 0)
            bodiPlayer.velocity = new Vector2(inputDirection.x, bodiPlayer.velocity.y); //
        else
        {
            if (hitJumpR)
                bodiPlayer.velocity = new Vector2(-hitJump * 1.2f, hitJump / 1.2f);
            if (!hitJumpR)
                bodiPlayer.velocity = new Vector2(hitJump * 1.2f, hitJump / 1.2f);
            hitJumpCont -= Time.deltaTime;
        }
        */
        //rigidybodyPlayer.AddForce(inputDirection);
        // velocity
        if (bodiPlayer.velocity.y > bodiPlayer.velocity.y + speedJump)
            bodiPlayer.velocity = new Vector2(inputDirection.x, bodiPlayer.velocity.y - speedJump);
        // direction
        /*
        if (inputDirection.x < 0)
            lookToRight = false;
        if (inputDirection.x > 0)
            lookToRight = true;
        if (lookToRight)
            transform.localScale = positionRight;
        else
            transform.localScale = positionLeft;
        */
        //    \direction

        if (bodiPlayer.velocity.x >= maxSpeed)
        {
            bodiPlayer.velocity = new Vector2(maxSpeed, bodiPlayer.velocity.y);
        }
        if (bodiPlayer.velocity.x < -maxSpeed)
        {
            bodiPlayer.velocity = new Vector2(-maxSpeed, bodiPlayer.velocity.y);
        }
        //

        //PlayerAnimator.SetFloat("velo", Mathf.Abs(inputDirection.x)); //valor inteiro

        // \movimento


    }
}
