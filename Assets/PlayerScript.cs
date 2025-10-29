using UnityEngine;

public class script : MonoBehaviour {

    Rigidbody2D rigidBody;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;
    public bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (grounded)
        {
            if (Input.GetAxis("Jump") > 0.0f)
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            else
        rigidBody.linearVelocity = new Vector2(speed * h, rigidBody.linearVelocityY);
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
