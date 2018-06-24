using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlothGameManager : MonoBehaviour {

    public SlothPlayerController player;

    private Vector2 playerStartPoint;

	// Use this for initialization
	void Start ()
    {
        playerStartPoint = player.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void RestartGame ()
    //{
    //    StartCoroutine (RestartGameCo ());

    //}

    //public IEnumerator RestartGameCo ()
    //{
    //    player.GameObject.setActive(false);
    //    yield return new WaitForSeconds(1f);
    //    player.transform.position = playerStartPoint;
    //    player.GameObject.setActive(true);
    //}
}
