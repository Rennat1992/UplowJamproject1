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
    public Image imageSlot4;
    public Image imageSlot5;
    public Image imageSlot6;
    public Image imageSlot7;
    public Image imageSlot8;
    public Image imageSlot9;

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
        imageSlot4 = GameObject.Find("Image4").GetComponent<Image>();
        imageSlot5 = GameObject.Find("Image5").GetComponent<Image>();
        imageSlot6 = GameObject.Find("Image6").GetComponent<Image>();
        imageSlot7 = GameObject.Find("Image7").GetComponent<Image>();
        imageSlot8 = GameObject.Find("Image8").GetComponent<Image>();
        imageSlot9 = GameObject.Find("Image9").GetComponent<Image>();

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
        imageSlot4.sprite = reset;
        imageSlot5.sprite = reset;
        imageSlot6.sprite = reset;
        imageSlot7.sprite = reset;
        imageSlot8.sprite = reset;
        imageSlot9.sprite = reset;

        //Disable button
        buttonPress.interactable = false;

        //go through all 3 slots
        int count = 0;

        while (count < 9)
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
            //slot1
            choice = Random.Range(0, 3);
            imageSlot1.sprite = slotItems[choice];

            //slot4
            choice = Random.Range(0, 3);
            imageSlot4.sprite = slotItems[choice];

            //slot7
            choice = Random.Range(0, 3);
            imageSlot7.sprite = slotItems[choice];
        }

        yield return new WaitForSeconds(1.0f);
        if (count == 1)
        {
            //slot2
            choice = Random.Range(0, 3);
            imageSlot2.sprite = slotItems[choice];

            //slot5
            choice = Random.Range(0, 3);
            imageSlot5.sprite = slotItems[choice];

            //slot8
            choice = Random.Range(0, 3);
            imageSlot8.sprite = slotItems[choice];
        }

        yield return new WaitForSeconds(1.0f);
        if (count == 2)
        {
            //slot3
            choice = Random.Range(0, 3);
            imageSlot3.sprite = slotItems[choice];

            //slot6
            choice = Random.Range(0, 3);
            imageSlot6.sprite = slotItems[choice];

            //slot9
            choice = Random.Range(0, 3);
            imageSlot9.sprite = slotItems[choice];

            //Check for rewards
            ACrossRewards();
            buttonPress.interactable = true;
        }

    }


    void ACrossRewards()
    {
        //Find names of sprite image
        //Debug.Log(imageSlot1.sprite.name.ToString());
        //Debug.Log(imageSlot1.sprite.name.ToString());
        //Debug.Log(imageSlot1.sprite.name.ToString());

        int mult;

        //slots 1->3 TRIPLE
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
        //slots 1->3 DOUBLES
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
                else
                {
                    Debug.Log("ERROR WITH SCORE!!!!");
                    mult = 0;
                }

                //Update score
                GreedGameData.GreedGameDataSingle.score += 50 * mult;
                GameObject.Find("Score").GetComponent<Text>().text = "Score: " + GreedGameData.GreedGameDataSingle.score.ToString();
            }
            else if ((imageSlot1.sprite.name.ToString() == imageSlot3.sprite.name.ToString()) || (imageSlot2.sprite.name.ToString() == imageSlot3.sprite.name.ToString()))
            {
                //Assign Score multiple
                if (imageSlot3.sprite.name.ToString() == "1")
                    mult = 1;
                else if (imageSlot3.sprite.name.ToString() == "2")
                    mult = 2;
                else if (imageSlot3.sprite.name.ToString() == "3")
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



            //slots 4->6 TRIPLE
            if ((imageSlot4.sprite.ToString() == imageSlot5.sprite.ToString()) && (imageSlot5.sprite.ToString() == imageSlot6.sprite.ToString()))
            {
                //Are they really all the same :thinking:
                //Debug.Log("ALL");
                //Debug.Log(imageSlot1.sprite.name.ToString());
                //Debug.Log(imageSlot1.sprite.name.ToString());
                //Debug.Log(imageSlot1.sprite.name.ToString());

                //Assign Score multiple
                if (imageSlot4.sprite.name.ToString() == "1")
                    mult = 1;
                else if (imageSlot4.sprite.name.ToString() == "2")
                    mult = 2;
                else if (imageSlot4.sprite.name.ToString() == "3")
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
            //slots 4->6 DOUBLES
            else if ((imageSlot4.sprite.name.ToString() == imageSlot5.sprite.name.ToString()) || (imageSlot4.sprite.name.ToString() == imageSlot6.sprite.name.ToString()) || (imageSlot5.sprite.name.ToString() == imageSlot6.sprite.name.ToString()))
            {
                //Are they really all the same :thinking:
                Debug.Log("MOTHERFUCKING PAIR BITCHES!!!");
                Debug.Log(imageSlot4.sprite.ToString());
                Debug.Log(imageSlot5.sprite.ToString());
                Debug.Log(imageSlot6.sprite.ToString());

                //Some kind of score system
                if (imageSlot4.sprite.name.ToString() == imageSlot5.sprite.name.ToString())
                {
                    //Assign Score multiple
                    if (imageSlot4.sprite.name.ToString() == "1")
                        mult = 1;
                    else if (imageSlot4.sprite.name.ToString() == "2")
                        mult = 2;
                    else if (imageSlot4.sprite.name.ToString() == "3")
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
                else if (imageSlot4.sprite.name.ToString() == imageSlot6.sprite.name.ToString())
                {
                    //Assign Score multiple
                    if (imageSlot4.sprite.name.ToString() == "1")
                        mult = 1;
                    else if (imageSlot4.sprite.name.ToString() == "2")
                        mult = 2;
                    else if (imageSlot4.sprite.name.ToString() == "3")
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
                else if (imageSlot4.sprite.name.ToString() == imageSlot6.sprite.name.ToString())
                {
                    //Assign Score multiple
                    if (imageSlot4.sprite.name.ToString() == "1")
                        mult = 1;
                    else if (imageSlot4.sprite.name.ToString() == "2")
                        mult = 2;
                    else if (imageSlot4.sprite.name.ToString() == "3")
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

            //slots 7->9 TRIPLE
            if ((imageSlot7.sprite.ToString() == imageSlot8.sprite.ToString()) && (imageSlot8.sprite.ToString() == imageSlot9.sprite.ToString()))
            {
                //Are they really all the same :thinking:
                //Debug.Log("ALL");
                //Debug.Log(imageSlot1.sprite.name.ToString());
                //Debug.Log(imageSlot1.sprite.name.ToString());
                //Debug.Log(imageSlot1.sprite.name.ToString());

                //Assign Score multiple
                if (imageSlot7.sprite.name.ToString() == "1")
                    mult = 1;
                else if (imageSlot7.sprite.name.ToString() == "2")
                    mult = 2;
                else if (imageSlot7.sprite.name.ToString() == "3")
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
            //slots 4->6 DOUBLES
            else if ((imageSlot7.sprite.name.ToString() == imageSlot8.sprite.name.ToString()) || (imageSlot7.sprite.name.ToString() == imageSlot9.sprite.name.ToString()) || (imageSlot8.sprite.name.ToString() == imageSlot9.sprite.name.ToString()))
            {
                //Are they really all the same :thinking:
                Debug.Log("MOTHERFUCKING PAIR BITCHES!!!");
                Debug.Log(imageSlot7.sprite.ToString());
                Debug.Log(imageSlot8.sprite.ToString());
                Debug.Log(imageSlot9.sprite.ToString());

                //Some kind of score system
                if (imageSlot7.sprite.name.ToString() == imageSlot8.sprite.name.ToString())
                {
                    //Assign Score multiple
                    if (imageSlot7.sprite.name.ToString() == "1")
                        mult = 1;
                    else if (imageSlot7.sprite.name.ToString() == "2")
                        mult = 2;
                    else if (imageSlot7.sprite.name.ToString() == "3")
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
                else if (imageSlot7.sprite.name.ToString() == imageSlot9.sprite.name.ToString())
                {
                    //Assign Score multiple
                    if (imageSlot7.sprite.name.ToString() == "1")
                        mult = 1;
                    else if (imageSlot7.sprite.name.ToString() == "2")
                        mult = 2;
                    else if (imageSlot7.sprite.name.ToString() == "3")
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
                else if (imageSlot7.sprite.name.ToString() == imageSlot9.sprite.name.ToString())
                {
                    //Assign Score multiple
                    if (imageSlot7.sprite.name.ToString() == "1")
                        mult = 1;
                    else if (imageSlot7.sprite.name.ToString() == "2")
                        mult = 2;
                    else if (imageSlot7.sprite.name.ToString() == "3")
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
}