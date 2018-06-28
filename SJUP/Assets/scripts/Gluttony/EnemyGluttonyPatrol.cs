using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGluttonyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;
    public Vector2 direction;

    public float yRotation = 5.0F;
    //Use this for initialization

    void Start() {

    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        //Cast a ray in the direction specified in the inspector.
                RaycastHit2D hit = Physics2D.Raycast(groundDetection.gameObject.transform.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if (movingRight == true)
            {transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
             transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;

            }

        }
    }


}