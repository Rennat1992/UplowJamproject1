using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAlpha2 : MonoBehaviour {

    public Color alph;
    public Transform play;

    public bool enter;

    //Singleton Motherfuckers!!!
    public static WallAlpha2 WallAlpha2Single;

    void Awake()
    {
        if (WallAlpha2Single == null)
        {
            DontDestroyOnLoad(gameObject);
            WallAlpha2Single = this;
        }
        else if (WallAlpha2Single != this)
        {
            Destroy(gameObject);
        }

        //currentQuest = 0f;
    }

    // Use this for initialization
    void Start()
    {
        alph = this.gameObject.GetComponent<SpriteRenderer>().color;

        play = GameObject.Find("Player").GetComponent<Transform>();
        enter = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (enter == false)
        {
            alph.a = 1f;
            this.gameObject.GetComponent<SpriteRenderer>().color = alph;
        }
        else if (enter == true)
        {
            alph.a = .5f;
            this.gameObject.GetComponent<SpriteRenderer>().color = alph;

            //behind walls
            play.position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x, GameObject.Find("Player").GetComponent<Transform>().position.y, -1);
            GameObject.Find("Player").GetComponent<Transform>().position = play.position;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            enter = !enter;
        }
    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.name == "Player")
    //    {
    //        Debug.Log("RICK JAMES BITCH");
    //        alph.a = 1f;
    //        this.gameObject.GetComponent<SpriteRenderer>().color = alph;
    //    }
    //}
}
