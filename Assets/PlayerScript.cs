using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private LayerMask PlatformLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private float jumpTimeCounter;
    public float jumptime;
    private bool isJumping;
    public float jumpVelocity = 75f;

    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space)){
        	isJumping = true;
        	jumpTimeCounter = jumptime;
        	float jumpVelocity = 75f;
        	rigidbody2d.velocity = Vector2.up * jumpVelocity;      	
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true){

        	if(jumpTimeCounter > 0){
        		rigidbody2d.velocity = Vector2.up * jumpVelocity;
        		jumpTimeCounter -= Time.deltaTime;
        	}else{
        		isJumping = false;
        	}
        }
        if (Input.GetKeyUp(KeyCode.Space)){
        	isJumping = false;
        }
        float moveSpeed = 25f;
        if (Input.GetKey(KeyCode.LeftArrow)){
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                //No Keys pressed
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }
    
    private bool isGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, PlatformLayerMask);
        return raycastHit2d.collider != null;

    }

    /*private void HandleMovement(){
       float moveSpeed = 10f;
        if (Input.GetKey(KeyCode.LeftArrow)){
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            }
            else
            {
                //No Keys pressed
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }*/
}
