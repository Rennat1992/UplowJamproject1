using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAlpha : MonoBehaviour {

    public Color alph;

    public bool enter;

    //Singleton Motherfuckers!!!
    public static WallAlpha WallAlphaSingle;

    void Awake()
    {
        if (WallAlphaSingle == null)
        {
            DontDestroyOnLoad(gameObject);
            WallAlphaSingle = this;
        }
        else if (WallAlphaSingle != this)
        {
            Destroy(gameObject);
        }

        //currentQuest = 0f;
    }

    // Use this for initialization
    void Start()
    {
        alph = this.gameObject.GetComponent<SpriteRenderer>().color;
        enter = false;
    }

	// Update is called once per frame
	void Update () {

        if (enter == false)
        {
            alph.a = 1f;
            this.gameObject.GetComponent<SpriteRenderer>().color = alph;
        }
        else if (enter == true)
        {
            alph.a = .5f;
            this.gameObject.GetComponent<SpriteRenderer>().color = alph;
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
