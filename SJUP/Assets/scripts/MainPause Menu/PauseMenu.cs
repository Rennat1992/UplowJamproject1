﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{


    //Canvas Element
    public Canvas Pause;

    //pause player control
    public GameObject playP;

    bool paused = false;


    void Start()
    {
        Pause  = this.gameObject.GetComponent<Canvas>();
        Pause.enabled = false;
        GameObject.Find("PauseImage").GetComponent<VideoPlayer>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.enabled = !Pause.enabled;
            GameObject.Find("PauseImage").GetComponent<VideoPlayer>().enabled = !GameObject.Find("PauseImage").GetComponent<VideoPlayer>().enabled;
            paused = togglePause();
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}