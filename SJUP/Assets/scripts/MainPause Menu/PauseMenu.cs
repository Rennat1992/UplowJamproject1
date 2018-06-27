using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{


    //Canvas Element
    public Canvas Pause;

    //puase player control
    public GameObject playP;

    bool paused = false;


    void Start()
    {
        Pause  = GameObject.Find("PauseMenu").GetComponent<Canvas>();
        Pause.enabled = false;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.enabled = !Pause.enabled;
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