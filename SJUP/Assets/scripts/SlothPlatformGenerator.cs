using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothPlatformGenerator : MonoBehaviour
{
    //public GameObject[] obj;
    //public float spawnMin = 1f;
    //public float spawnMax = 2f;

    //void Start ()
    //{
    //    Spawn ();
    //}

    //void Spawn ()
    //{
    //    Instantiate (obj[Random.Range(0, obj.Length / 2)], transform.position, Quaternion.identity);
    //    Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
    //}






    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public SlothObjectPooler theObjectPool;


    //Use this for initialization

    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

    }

    //Update is called once per frame

    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate (platform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject ();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive (true);
        }
    }
}
