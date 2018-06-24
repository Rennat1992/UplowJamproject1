using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothGameControlsScript : MonoBehaviour
{
    public static float MAX_SPEED = 10000f;


    [HideInInspector]
    public bool jump = true;

    public float moveForce { get; set; }
    public float speed;
    public float jumpForce;
    public float inAirForce;
    public float speedUpCheckpoint = 1000f;
    public float speedMultiplier = 1.5f;
    public float jumpTime;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Collider2D myCollider;


    public bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    private float speedUpCount;
    private float jumpTimeCount;

    // Use this for initialization
    void Start()
    {
        jump = false;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(10, rb2d.velocity.y);
        myCollider = GetComponent<Collider2D>();
        speedUpCount = speedUpCheckpoint;
        jumpTimeCount = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (rb2d.position.x > speedUpCount)
        {
            speed *= speedMultiplier;
            speedUpCheckpoint *= speedMultiplier;
            speedUpCount += speedUpCheckpoint;
        }

        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

   //     rb2d.velocity = new Vector2(rb2d.velocity.x + speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCount > 0)
            {
                rb2d.AddForce(new Vector2(rb2d.velocity.x, inAirForce));
                jumpTimeCount -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCount = 0;
        }
        if (grounded)
        {
            jumpTimeCount = jumpTime;
        }

    }

    //void FixedUpdate()
    //{


    //    if (jump)
    //    {
    //        rb2d.gravityScale = 10;
    //        if (rb2d.velocity.y < 0)
    //        {
    //            rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
    //        }
    //        if (Mathf.Sign(rb2d.velocity.y) < 1.2f)
    //            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
    //        if (Mathf.Sign(rb2d.velocity.y) > 1.2f)
    //            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign(rb2d.velocity.y) * 0.2f);
    //        jump = false;
    //    }
    //}
}
