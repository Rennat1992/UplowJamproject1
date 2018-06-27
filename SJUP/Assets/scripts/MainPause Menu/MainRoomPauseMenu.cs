using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainRoomPauseMenu : MonoBehaviour
{


    //Canvas Element
    public Canvas Pause;

    //puase player control
    public MainRoomControls playP;

    bool paused = false;


    void Start()
    {
        playP = GameObject.Find("Player").GetComponent<MainRoomControls>();
        Pause = GameObject.Find("PauseMenu").GetComponent<Canvas>();
        Pause.enabled = false;
        playP.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playP.enabled = !playP.enabled;
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