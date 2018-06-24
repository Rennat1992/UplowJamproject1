using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyPatrol : MonoBehaviour
{
    public float speed = 5;
    public float time = 1;
    public float distance = 1;

    private bool movingRight = true;
    private bool movingLeft = true;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            movingRight = true;
            movingLeft = false;
        }
        else if (groundInfo.collider == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }

 
            

        

        }
}