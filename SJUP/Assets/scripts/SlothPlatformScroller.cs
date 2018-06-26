//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SlothPlatformScroller : MonoBehaviour {

//    public float scrollSpeed = 5.0f;

//	// Use this for initialization
//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update ()
//    {
//        //Scrolling
//        GameObject currentChild;
//        for (int i = 0; i < tansform.childCount; i++)
//        {
//            currentChild = tansform.GetChild(i).gameObject;
//            ScrollPlatform (currentChild);
//        }
//	}


//    void ScrollPlatform (GameObject currentPlatform)
//    {
//        currentPlatform.tansform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);

//    }
//}
