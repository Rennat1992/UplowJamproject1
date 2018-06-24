using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedSpinToWin : MonoBehaviour {

    private CanvasGroup SlotCanvas;


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
		
	}
	
	// Update is called once per frame
	void Update () {
		if (slotMachine == true)
        {
            PlaySlots();
        }
	}

    void PlaySlots()
    {

    }
}
