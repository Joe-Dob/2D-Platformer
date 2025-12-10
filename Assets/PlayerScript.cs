using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rigidBody;
    Animator animator;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce;
    public float airControlMax;
    public bool grounded;
    public bool canDoubleJump;
    private bool isDoubleJumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canDoubleJump = false;
        isDoubleJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xspeed = Mathf.Abs(rigidBody.linearVelocity.x);
        animator.SetFloat("xspeed", xspeed);
        if (rigidBody.linearVelocity.x * transform.localScale.x < 0.0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void Jump()
    {
        if(!isDoubleJumping)
        {
            rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            rigidBody.AddForce(new Vector2(0.0f, jumpForce*5f), ForceMode2D.Impulse);
        }
            
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (grounded)
        {
            canDoubleJump = true;
            isDoubleJumping= false;
            if (Input.GetAxis("Jump") > 0.0f) //0++++++++
            {
                //I can double jump because I have just jumped...
                Jump();
                //canDoubleJump = true;

            }
            else
            {
                //I am walking...
                //No, I haven't jumped once yet...
                rigidBody.linearVelocity = new Vector2(speed * h, rigidBody.linearVelocity.y);
                //canDoubleJump = false;
            }
        }
        else
        {
            // this allows the player a small amount of movement in the air
            float vx = rigidBody.linearVelocityX;
            if (h * vx < airControlMax)
                rigidBody.AddForce(new Vector2(h * airControlForce, 0));

            //So, I can double jump here, but should I throttle this in any way?
            //What if I can jump to infinity?  
            //Have I used double jump? If so, no more double jump for you...
            //if I have the ability to double jump and the player presses jump, jump!
            if(canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {

                Debug.Log("double jump");                
                //Add the new jump
                Jump();
                canDoubleJump = false;
                isDoubleJumping = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if(Collision.gameObject.layer == 3)
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D Collision)
    {
        if(Collision.gameObject.layer == 3)
        {
            grounded = false;
        }

    }
}
