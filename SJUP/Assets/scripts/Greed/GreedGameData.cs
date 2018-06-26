using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreedGameData : MonoBehaviour {

    //Singleton Motherfuckers!!!
    public static GreedGameData GreedGameDataSingle;

    void Awake()
    {
        if (GreedGameDataSingle == null)
        {
            DontDestroyOnLoad(gameObject);
            GreedGameDataSingle = this;
        }
        else if (GreedGameDataSingle != this)
        {
            Destroy(gameObject);
        }
    }

    public int score = 0;
    public int funds = 1000;

    // Use this for initialization
    void Start () {
        GameObject.Find("Funds").GetComponent<Text>().text = "Cash Money: " + funds.ToString();
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
