using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour{

    Rigidbody2D rigidBody;
    public float speed;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;

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
        if ( h != 0.0f )
            rigidBody.linearVelocity = new Vector2(h * speed, 0.0f);
    }
}
