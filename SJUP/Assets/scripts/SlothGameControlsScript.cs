using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothGameControlsScript : MonoBehaviour
{
    public static float INC_SPEED = 10;

    [HideInInspector]
    public bool jump = true;
    public bool grounded = false;
    public LayerMask whatIsGround;

    public float moveForce { get; set; }
    public float speed = 10f;
    public float jumpForce = 100f;
    public Transform groundCheck;

    private Collider2D myCollider;


    //private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        jump = false;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);


        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) /*&& grounded*/)
        {
            jump = true;
            rb2d.gravityScale = 10;
            
        }
    }

    void FixedUpdate()
    {
        if (jump && grounded)
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

        if (Mathf.Sign(rb2d.velocity.x) > 15f)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * 0.995f, rb2d.velocity.y);
        }
    }
}
