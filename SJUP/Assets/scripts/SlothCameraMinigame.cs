using UnityEngine;
using System.Collections;

public class SlothCameraMinigame : MonoBehaviour
{

    public GameObject player;


    // Use this for initialization
    void Start()
    {
        transform.Rotate(Vector3.zero);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + 5, 0, -10);
        transform.Rotate(Vector3.zero);
    }
}
