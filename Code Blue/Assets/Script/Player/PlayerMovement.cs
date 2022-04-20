using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player movement class, a general class for handling physics, movement and the animations as its related to movement 
    //also added some more quality of life features for better platformer movement 
    //Refactor to remove the wall jumping mechanic 
    //Refactor to be able to add jump buffer and hangtime

    [Header("Movement finetuning ")]
    [SerializeField]
    [Range(7.5f, 12.5f)]
    private float speed;
    [SerializeField]
    [Range(.1f, .75f)]
    private float miniJumpScale;

    [SerializeField]
    [Range(5.0f, 10.0f)]
    private float jumpPower;

    [SerializeField] private float hangTime;
    private float hangCounter;

    [SerializeField] private float jumpBufferLength;
    private float jumpBufferCount;

    private Animator anim;
    private BoxCollider2D boxCollider2D;
    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private float wallJumpCoolDown;
    private float horizontalInput;

    [SerializeField]private float normalGravityScale;

    private Rigidbody2D body;

    private bool freezePlayer = false;

    

    [Header("camera target fields")]
    public Transform camTarget;
    public float aheadAmount, aheadSpeed;
    private void Awake()
    {
        //Grab referneces inside the gameobject 
        //refactor, do it if its null
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
       
    }

    private void Update()
    {

       
        //move left/right
        if(freezePlayer)
        {
            //set player animation to idle?
            return;
        }
         horizontalInput = Input.GetAxis("Horizontal");
      

        //Flip player when moving left 
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

         //set animator parameters
         anim.SetBool("run", horizontalInput != 0);
         anim.SetBool("grounded", isGrounded());

     
       
         body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //manage hangtime 
        if(isGrounded())
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
        //manage jump buffer
        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime; 
        } 
      
       

        if (jumpBufferCount >= 0 && hangCounter > 0 )
                Jump();
       
       
        //mini jump feature
        if (Input.GetButtonUp("Jump") && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * miniJumpScale);
        }
    }



    private void Jump()
    {
       
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");
        hangCounter = 0;
        jumpBufferCount = 0;
    }

  

    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);


        return raycastHit.collider != null;
    }


    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0,new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }


    public void FreezePlayer()
    {
        body.velocity = Vector2.zero;
        freezePlayer = true;
    }

    public void UnFreezePlayer()
    {
        freezePlayer = false;
    }


}
