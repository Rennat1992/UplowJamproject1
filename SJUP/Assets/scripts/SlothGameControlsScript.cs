using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothGameControlsScript : MonoBehaviour
{
    public static float MAX_SPEED = 10000f;

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = true;

    public float moveForce { get; set; }
    public float speed = .01f;
    public float jumpForce = 100f;
    public Transform groundCheck;

    //private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        jump = false;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(10, rb2d.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

        rb2d.velocity = new Vector2(rb2d.velocity.x + speed, rb2d.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) /*&& grounded*/)
        {
            jump = true;
            rb2d.gravityScale = 10;
            
        }
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal");
        //anim.SetFloat("Speed", Mathf.Abs(h));


        /*if (h * rb2d.velocity.x < maxSpeed)
            rb2d.velocity = new Vector2(h * maxSpeed, rb2d.velocity.y);*/

        /*
        if (h > 0 && !facingRight)
            Flip();

        if (h < 0 && facingRight)
            Flip();
        */

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

        if (Mathf.Sign(rb2d.velocity.x) > 15f)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * 0.995f, rb2d.velocity.y);
        }
    }


    /*
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    */
}
