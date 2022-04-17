using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField]
    [Range(5.0f, 15.0f)]
    private float speed;

    [SerializeField]
    [Range(5.0f, 15.0f)]
    private float jumpPower;
    private Animator anim;
    private BoxCollider2D boxCollider2D;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private float wallJumpCoolDown;
    private float horizontalInput;

    [SerializeField]private float normalGravityScale;

    private Rigidbody2D body;

    private bool freezePlayer = false;
 

    private void Awake()
    {
        //Grab referneces inside the gameobject 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
      
        //move left/right
        if(freezePlayer)
        {
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


        if (wallJumpCoolDown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = normalGravityScale;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCoolDown += Time.deltaTime;
    }



    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCoolDown = 0;
        }
    }



   
    private bool isGrounded()
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
