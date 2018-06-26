using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreedSlotExit : MonoBehaviour {

    private CanvasGroup SlotCanvas;

    public Button buttonPress;

    private void Start()
    {
        SlotCanvas = GameObject.Find("SlotCanvas").GetComponent<CanvasGroup>();
        buttonPress = GameObject.Find("Exit").GetComponent<Button>();

        buttonPress.onClick.AddListener(TaskOnClick);
    }
    // Use this for initialization
    void TaskOnClick()
    {
        SlotCanvas.alpha = 0;
        SlotCanvas.blocksRaycasts = false;
        SlotCanvas.interactable = false;
    }

}
