using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;

    void Start ()
    {
        platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");

    }

    void Update ()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy (gameObject);

            gameObject.SetActive (false);
        }
    }







    //void OnTriggerEnter2D (Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Break ();
    //        return;
    //    }

    //    if (other.gameObject.transform.parent)
    //    {
    //        Destroy (other.gameObject.transform.parent.gameObject);
    //    }
    //    else
    //    {
    //        Destroy (other.gameObject);
    //    }
    //}
    
}
