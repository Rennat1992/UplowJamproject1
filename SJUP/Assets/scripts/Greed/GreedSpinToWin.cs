using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreedSpinToWin : MonoBehaviour {

    private CanvasGroup SlotCanvas;

    //Holds slot sprites
    public Dictionary<int, Sprite> slotItems = new Dictionary<int, Sprite>();
    public Sprite Spin1;
    public Sprite Spin2;
    public Sprite Spin3;

    //Slot image changers
    public Image imageSlot1;
    public Image imageSlot2;
    public Image imageSlot3;

    //button
    private Button buttonPress;

    //thing to check!
    public bool slotMachine = false;

    //Singleton Motherfuckers!!!
    public static GreedSpinToWin GreedSpinToWinSingle;

    void Awake()
    {
        if (GreedSpinToWinSingle == null)
        {
            DontDestroyOnLoad(gameObject);
            GreedSpinToWinSingle = this;
        }
        else if (GreedSpinToWinSingle != this)
        {
            Destroy(gameObject);
        }

        //currentQuest = 0f;
    }

    void Start () {
        //Add sprite to roulette
        slotItems.Add(0, Spin1);
        slotItems.Add(1, Spin2);
        slotItems.Add(2, Spin3);

        //Assigning public images
        imageSlot1 = GameObject.Find("Image1").GetComponent<Image>();
        imageSlot2 = GameObject.Find("Image2").GetComponent<Image>();
        imageSlot3 = GameObject.Find("Image3").GetComponent<Image>();

        //Setup Button
        buttonPress = GameObject.Find("Spin").GetComponent<Button>();

        buttonPress = GameObject.Find("Spin").GetComponent<Button>();
        buttonPress.onClick.AddListener(PlaySlots);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void PlaySlots()
    {

        //Disable button
        buttonPress.interactable = false;

        //go through all 3 slots
        int count = 0;

        while (count < 3)
        {
            WaitAMoment(2.0f);
            if (count == 0)
            {
                imageSlot1.sprite = slotItems[0];
            }
            if (count == 1)
            {
                imageSlot2.sprite = slotItems[1];
            }
            if (count == 2)
            {
                imageSlot3.sprite = slotItems[2];
            }

            //Wait 2 seconds
            //WaitAMoment(2.0f);
            count++;
        }

        //Reactivate button
        buttonPress.interactable = true;
    }

    //Wait
    IEnumerator WaitAMoment(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
