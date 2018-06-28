using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedCanvasSetup : MonoBehaviour {

    //Moving item when canvas is hidden
    private RectTransform invRect;
    private float invWidth, invHeight;

    private List<GameObject> allSlots;
    private static int emptySlots;

    //Grid up the Canvas
    public int slots;
    public int rows;
    public float slotPaddingLeft, slotPaddingTop;
    public float slotSize;

    private Canvas canvas;

    private float hoverYOffset;

    public static GreedCanvasSetup GreedCanvasSetupSingle;

    //Canvas elements
    public GameObject slotPrefab;

    //Maybe never need
    void Awake()
    {
        if (GreedCanvasSetupSingle == null)
        {
            GreedCanvasSetupSingle = this;
        }
        else if (GreedCanvasSetupSingle != this)
        {
            Destroy(gameObject);
        }
    }



    // Use this for initialization
    void Start () {

        //reference to canvas
        slotSize = GameObject.Find("TempCanvas(WIP)").GetComponent<RectTransform>().rect.width / 13;
        canvas = (Canvas)GetComponentInParent(typeof(Canvas));
        CreateLayout();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateLayout()
    {
        allSlots = new List<GameObject>();

        emptySlots = slots;

        invWidth = (slots / rows) * slotSize;
        invHeight = rows * slotSize;

        invRect = GetComponent<RectTransform>();
        invRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, invWidth);
        invRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invHeight);

        int columns = slots / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                if(y == 1 && x == 1)
                {
                    GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                    RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                    newSlot.name = "Slot1";
                    newSlot.transform.SetParent(this.transform.parent);
                    //Inventory slots
                    slotRect.localPosition = invRect.localPosition + new Vector3((x + 1) + (slotSize * x), (y + 1) - (slotSize * y));
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                    allSlots.Add(newSlot);
                    newSlot.transform.SetParent(this.transform);
                }
                if (y == 3 && x == 3)
                {
                    GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                    RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                    newSlot.name = "Slot2";
                    newSlot.transform.SetParent(this.transform.parent);
                    //Inventory slots
                    slotRect.localPosition = invRect.localPosition + new Vector3((x + 1) + (slotSize * x), (y + 1) - (slotSize * y));
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                    allSlots.Add(newSlot);
                    newSlot.transform.SetParent(this.transform);
                }
                if (y == 5 && x == 5)
                {
                    GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                    RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                    newSlot.name = "Slot3";
                    newSlot.transform.SetParent(this.transform.parent);
                    //Inventory slots
                    slotRect.localPosition = invRect.localPosition + new Vector3((x + 1) + (slotSize * x), (y + 1) - (slotSize * y));
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                    slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                    allSlots.Add(newSlot);
                    newSlot.transform.SetParent(this.transform);
                }

            }
        }
    }
}
