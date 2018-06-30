using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRoomControls : MonoBehaviour
{

    [HideInInspector]
    public bool facingRight = true;

    //touching a door
    public bool sloth = false;

    //touching a door
    public bool gluttony = false;

    //touching a door
    public bool greed = false;

    public float maxSpeed = 10f;

    public Transform groundCheck;

    //private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    //Wall transparent (cant spell)
    private Color alph;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //why????
    void Update()
    {
        //if (Input.GetButton("D") && Input.GetButton("A"))
        //{
        //    rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        //}

        //if (Input.GetButton("W") && Input.GetButton("S"))
        //{
        //    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        //}

        if (Input.GetKeyDown(KeyCode.Q) && sloth == true)
        {
            StartCoroutine(LoadSloth());
        }

        if (Input.GetKeyDown(KeyCode.Q) && gluttony == true)
        {
            StartCoroutine(LoadGluttony());
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.velocity = new Vector2(h * maxSpeed, y * maxSpeed);

        if (y * rb2d.velocity.y < maxSpeed)
            rb2d.velocity = new Vector2(h * maxSpeed, y * maxSpeed);

        if (h > 0 && !facingRight)
            Flip();

        if (h < 0 && facingRight)
            Flip();


        if (Mathf.Sign(rb2d.velocity.x) > 15f)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * 0.995f, rb2d.velocity.y);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("door");
        if (col.gameObject.name == "SlothDoor")
        {
            Debug.Log("door");
            sloth = true;
        }

        if (col.gameObject.name == "GluttonyDoor")
        {
            Debug.Log("door");
            gluttony = true;
        }

        if (col.gameObject.name == "GreedDoor")
        {
            //Debug.Log("door"); Just use the chest for now
            //greed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("door");
        if (col.gameObject.name == "SlothDoor")
        {
            sloth = false;
        }

        if (col.gameObject.name == "GluttonyDoor")
        {
            gluttony = false;
        }

        if (col.gameObject.name == "GreedDoor")
        {
            //Temp shit
            //greed = false;
        }
        if (col.gameObject.tag == "Wall")
        {
            alph = col.gameObject.GetComponent<SpriteRenderer>().color;
            alph.a = 255f;
            col.gameObject.GetComponent<SpriteRenderer>().color = alph;
        }
    }


    IEnumerator LoadSloth()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Sloth");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadGluttony()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Gluttony");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
