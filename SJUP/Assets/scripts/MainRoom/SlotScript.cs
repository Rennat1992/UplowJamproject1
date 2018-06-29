using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour {

    private CanvasGroup SlotCanvas;


    // Use this for initialization
    void Start () {
        SlotCanvas = GameObject.Find("SlotCanvas").GetComponent<CanvasGroup>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            SlotCanvas.alpha = 1;
            SlotCanvas.blocksRaycasts = true;
            SlotCanvas.interactable = true;
            GreedSpinToWin.GreedSpinToWinSingle.slotMachine = true;

            GameObject.Find("Player").GetComponent<MainRoomControls>().enabled = false;
        }
    }
}
