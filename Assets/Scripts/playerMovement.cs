using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public float floatSpeed;
    public float floatTime;
    private float originalGravity;
    private float originalFloatTime;
    private bool floatTimeDelay = false;
    private Rigidbody2D rigidbody2D;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;


    // Use this for initialization
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalGravity = rigidbody2D.gravityScale;
        originalFloatTime = floatTime;
    }


    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump") && grounded){ 
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
        }

        if(Input.GetButton("Jump") && grounded==false && floatTimeDelay == false){
            if(floatTime >= 0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, floatSpeed);
                rigidbody2D.gravityScale = 1;
                floatTime -= 0.5f;
            }
            if (floatTime <= 0) {
                floatTimeDelay = true;
                rigidbody2D.gravityScale = originalGravity;
            }
        }
        if (floatTime < originalFloatTime && grounded)
            floatTime += 0.2f;
        if (floatTime >= originalFloatTime && grounded)
        {
            floatTimeDelay = false;
            floatTime = originalFloatTime;
        }

        if (Input.GetAxis("Horizontal") > 0)
            rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);

        if (Input.GetAxis("Horizontal") < 0)
            rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
    }
}
