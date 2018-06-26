using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothPlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float inAirForce;
    public float speedUpCheckpoint;
    public float speedMultiplier;
    public float jumpTime;
    public float deathHeight;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsDeath;
    public Collider2D myCollider;
    public Rigidbody2D rb2d;
    public SlothGameManager gameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    public bool grounded = false;
    public bool moving = false;

    private Animator anim;
    private float speedUpCount;
    private float jumpTimeCount;
    private Vector2 playerStartPoint;
    public float oldXPosition;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
        myCollider = GetComponent<Collider2D>();
        speedUpCount = speedUpCheckpoint;
        jumpTimeCount = jumpTime;
        playerStartPoint = rb2d.position;
       // oldXPosition = rb2d.position.x - 1;
    }

    // Update is called once per frame
    void Update()
    {

        //Update velocity
        rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);

        //Check if player is moving or stopped by wall - BROKEN
        moving = (rb2d.position.x < 0);

        //checks if player died
        if ((rb2d.position.y < deathHeight) || !moving)
        {
           // StartCoroutine(RestartGameCo());
        }

        //Checks if player is on the ground
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //If player reaches checkpoint, scale the speed and distance to next checkpoint
        if (rb2d.position.x > speedUpCount)
        {
            speed *= speedMultiplier;
            speedUpCheckpoint *= speedMultiplier;
            speedUpCount += speedUpCheckpoint;
        }

        //Checks if player presses jump and is able to jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
            jumpSound.Stop ();
            jumpSound.Play ();
        }

        //Checks if player holds down space for long jump
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCount > 0)
            {
                rb2d.AddForce(new Vector2(rb2d.velocity.x, inAirForce));
                jumpTimeCount -= Time.deltaTime;
            }
        }

        //Checks if player releases space bar to end long jump
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCount = 0;
        }

        //Checks if player is grounded to reset long jump
        if (grounded)
        {
            jumpTimeCount = jumpTime;
        }


    }


    //Stuff for restarting the game post death
    public IEnumerator RestartGameCo()
    {
        rb2d.velocity = new Vector2(speed, 0);
        yield return new WaitForSeconds(2f);
        rb2d.position = playerStartPoint;
        rb2d.velocity = new Vector2(speed, 0);
        oldXPosition = rb2d.position.x - 1;
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionStay2D (Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D (Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            grounded = false;
        }
    }
}
