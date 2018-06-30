using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothGameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public SlothPlayerController player;
    private Vector3 playerStartPoint;

    public SlothDestroyer[] platformArray;

	// Use this for initialization
	void Start ()
    {
        playerStartPoint = player.transform.position;
        platformStartPoint = platformGenerator.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void RestartGame()
    {
        StartCoroutine ("RestartGameCo");

    }

    public IEnumerator RestartGameCo ()
    {

        //player.gameObject.setActive(false);
        yield return new WaitForSeconds(1f);
        platformArray = FindObjectsOfType<SlothDestroyer> ();
        for ( int i = 0; i < platformArray.Length; i++)
        {
            platformArray[i].gameObject.SetActive (false);
        }
        player.transform.position = playerStartPoint;

        platformGenerator.position = platformStartPoint;
        //player.gameObject.setActive(true);
    } 
}
