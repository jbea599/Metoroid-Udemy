using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint;
    private bool isOnGround;
    public LayerMask whatIsGround;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        //Direction checking
        if(theRB.velocity.x < 0){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }


        //Vertical movement 
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
        
        if (Input.GetButtonDown("Jump") && isOnGround) {

            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }








        //Animator mapping
        animator.SetBool("isOnGround", isOnGround);
        animator.SetFloat("speed", Mathf.Abs(theRB.velocity.x));



    }
}
