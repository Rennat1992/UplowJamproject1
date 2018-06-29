using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHelper1 : MonoBehaviour {

    //change player position
    public Transform play;

    // Use this for initialization
    void Start () {
        play = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player"){
            WallAlpha.WallAlphaSingle.enter = false;

            //behind walls
            play.position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x, GameObject.Find("Player").GetComponent<Transform>().position.y, -4);
            GameObject.Find("Player").GetComponent<Transform>().position = play.position;
        }
    }
}
