using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRoomControls : MonoBehaviour
{

    [HideInInspector]
    public bool facingRight = true;

    //touching a door
    public bool check = false;

    public float maxSpeed = 10f;

    public Transform groundCheck;

    //private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

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

        if (Input.GetKeyDown(KeyCode.Q) && check == true)
        {
            StartCoroutine(LoadYourAsyncScene());
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
            check = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("door");
        if (col.gameObject.name == "SlothDoor")
        {
            check = false;
        }
    }


    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Sloth");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
