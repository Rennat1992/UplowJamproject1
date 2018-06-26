using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreedSpinToWin : MonoBehaviour
{

    private CanvasGroup SlotCanvas;

    //Reset Sprite
    public Sprite reset;

    //Update UI Text
    private Text textUpdateFunds;

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

    //TimeDelay
    private IEnumerator coroutine;

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

    void Start()
    {
        //Add sprite to roulette
        slotItems.Add(0, Spin1);
        slotItems.Add(1, Spin2);
        slotItems.Add(2, Spin3);

        //Assigning public images
        imageSlot1 = GameObject.Find("Image1").GetComponent<Image>();
        imageSlot2 = GameObject.Find("Image2").GetComponent<Image>();
        imageSlot3 = GameObject.Find("Image3").GetComponent<Image>();

        //Setup Updated Text
        textUpdateFunds = GameObject.Find("Funds").GetComponent<Text>();

        //Setup Button
        buttonPress = GameObject.Find("Spin").GetComponent<Button>();

        buttonPress = GameObject.Find("Spin").GetComponent<Button>();
        buttonPress.onClick.AddListener(PlaySlots);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlaySlots()
    {
        //Subtract funds
        GreedGameData.GreedGameDataSingle.funds = GreedGameData.GreedGameDataSingle.funds - 100;
        textUpdateFunds.text = "Cash Money: " + GreedGameData.GreedGameDataSingle.funds.ToString();

        //reset sprite
        imageSlot1.sprite = reset;
        imageSlot2.sprite = reset;
        imageSlot3.sprite = reset;

        //Disable button
        buttonPress.interactable = false;

        //go through all 3 slots
        int count = 0;

        while (count < 3)
        {
            //This shit only works on teh stuff INSIDE of the IEnumerator function...... fucking hate it
            StartCoroutine(WaitAMoment(count));
            count++;
        }
    }

    //Wait
    IEnumerator WaitAMoment(int count)
    {
        //wait 2 seconds

        yield return new WaitForSeconds(1.0f);

        int choice;

        if (count == 0)
        {
            choice = Random.Range(0, 3);
            imageSlot1.sprite = slotItems[choice];
        }

        yield return new WaitForSeconds(1.0f);
        if (count == 1)
        {
            choice = Random.Range(0, 3);
            imageSlot2.sprite = slotItems[choice];
        }

        yield return new WaitForSeconds(1.0f);
        if (count == 2)
        {
            choice = Random.Range(0, 3);
            imageSlot3.sprite = slotItems[choice];

            //Reactivate button after last image change
            BigBucks();
            buttonPress.interactable = true;
        }
    }


    void BigBucks()
    {
        //Find names of sprite image
        //Debug.Log(imageSlot1.sprite.name.ToString());
        //Debug.Log(imageSlot1.sprite.name.ToString());
        //Debug.Log(imageSlot1.sprite.name.ToString());

        int mult;

        if ((imageSlot1.sprite.ToString() == imageSlot2.sprite.ToString()) && (imageSlot2.sprite.ToString() == imageSlot3.sprite.ToString()))
        {
            //Are they really all the same :thinking:
            //Debug.Log("ALL");
            //Debug.Log(imageSlot1.sprite.name.ToString());
            //Debug.Log(imageSlot1.sprite.name.ToString());
            //Debug.Log(imageSlot1.sprite.name.ToString());

            //Assign Score multiple
            if (imageSlot1.sprite.name.ToString() == "1")
                mult = 1;
            else if (imageSlot1.sprite.name.ToString() == "2")
                mult = 2;
            else if (imageSlot1.sprite.name.ToString() == "3")
                mult = 3;
            else
            {
                Debug.Log("ERROR WITH SCORE!!!!");
                mult = 0;
            }

            //Some kind of score system
            GreedGameData.GreedGameDataSingle.score += 1000 * mult;
            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + GreedGameData.GreedGameDataSingle.score.ToString();
        }
        else if ((imageSlot1.sprite.name.ToString() == imageSlot2.sprite.name.ToString()) || (imageSlot1.sprite.name.ToString() == imageSlot3.sprite.name.ToString()) || (imageSlot2.sprite.name.ToString() == imageSlot3.sprite.name.ToString()))
        {
            //Are they really all the same :thinking:
            Debug.Log("MOTHERFUCKING PAIR BITCHES!!!");
            Debug.Log(imageSlot1.sprite.ToString());
            Debug.Log(imageSlot2.sprite.ToString());
            Debug.Log(imageSlot3.sprite.ToString());

            //Some kind of score system
            if (imageSlot1.sprite.name.ToString() == imageSlot2.sprite.name.ToString())
            {
                //Assign Score multiple
                if (imageSlot1.sprite.name.ToString() == "1")
                    mult = 1;
                else if (imageSlot1.sprite.name.ToString() == "2")
                    mult = 2;
                else if (imageSlot1.sprite.name.ToString() == "3")
                    mult = 3;
                else { 
                Debug.Log("ERROR WITH SCORE!!!!");
                mult = 0;
                }

                //Update score
                GreedGameData.GreedGameDataSingle.score += 50 * mult;
                GameObject.Find("Score").GetComponent<Text>().text = "Score: " + GreedGameData.GreedGameDataSingle.score.ToString();
            }
            else if (imageSlot1.sprite.name.ToString() == imageSlot3.sprite.name.ToString())
            {
                //Assign Score multiple
                if (imageSlot1.sprite.name.ToString() == "1")
                    mult = 1;
                else if (imageSlot1.sprite.name.ToString() == "2")
                    mult = 2;
                else if (imageSlot1.sprite.name.ToString() == "3")
                    mult = 3;
                else
                {
                    Debug.Log("ERROR WITH SCORE!!!!");
                    mult = 0;
                }

                //Update score
                GreedGameData.GreedGameDataSingle.score += 50 * mult;
                GameObject.Find("Score").GetComponent<Text>().text = "Score: " + GreedGameData.GreedGameDataSingle.score.ToString();
            }
            else if (imageSlot2.sprite.name.ToString() == imageSlot3.sprite.name.ToString())
            {
                //Assign Score multiple
                if (imageSlot2.sprite.name.ToString() == "1")
                    mult = 1;
                else if (imageSlot2.sprite.name.ToString() == "2")
                    mult = 2;
                else if (imageSlot2.sprite.name.ToString() == "3")
                    mult = 3;
                else
                {
                    Debug.Log("ERROR WITH SCORE!!!!");
                    mult = 0;
                }

                //Update score
                GreedGameData.GreedGameDataSingle.score += 50 * mult;
                GameObject.Find("Score").GetComponent<Text>().text = "Score: " + GreedGameData.GreedGameDataSingle.score.ToString();
            }
        }
    }
}