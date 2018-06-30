﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToHub : MonoBehaviour
{

    public Button buttonPress;

    private void Start()
    {
        buttonPress = GameObject.Find("Hub").GetComponent<Button>();

        buttonPress.onClick.AddListener(TaskOnClick);
    }

    // Use this for initialization
    void TaskOnClick()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Hub");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
