using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothGameControlsScript : MonoBehaviour
{
    public static float MAX_SPEED = 10000f;


    [HideInInspector]
    public bool jump = true;


    public float moveForce { get; set; }
    public float speed = .01f;
    public float jumpForce = 100f;
    public float speedUpCheckpoint = 1000f;
    public float speedMultiplier = 1.5f;
    public Transform groundCheck;
    public Collider2D myCollider;
    public LayerMask whatIsGround;
    public bool grounded = false;

    private Animator anim;
    private Rigidbody2D rb2d;
    private float speedUpCount = 0;

    // Use this for initialization
    void Start()
    {
        jump = false;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(10, rb2d.velocity.y);
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if player is on ground
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //incrementing speed and checkpoint distance to keep time with each speed consistent
        if (transform.position.x > speedUpCount)
        {
            speed *= speedMultiplier;
            speedUpCheckpoint *= speedMultiplier;
            speedUpCount += speedUpCheckpoint;

        }
        
        //Set speed
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        //Check if the player attempts to jump while grounded
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
            rb2d.gravityScale = 10;

        }
    }

    void FixedUpdate()
    {

        //jump mechanics
        if (jump)
        {
            rb2d.gravityScale = 10;
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
            }
            if (Mathf.Sign(rb2d.velocity.y) < 1.2f)
                rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
            if (Mathf.Sign(rb2d.velocity.y) > 1.2f)
                rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign(rb2d.velocity.y) * 0.2f);
            jump = false;
        }
    }


}