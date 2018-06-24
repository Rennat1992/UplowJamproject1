using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyPatrol : MonoBehaviour
{
    public float speed = 1;
    public float time = 1;
    public float distance = 1;
    public Transform transform;
              
    private bool movingRight = true;
    private bool movingLeft = true;

    // This is our direction we're travelling in.
    Vector3 direction = new Vector3(1, 0, 0);

        // Move it along its direction.
    void Update()
    {
        transform.Translate(direction.x * Time.deltaTime, 0,0);
    }
    
    // If we hit a left or right wall, invert x direction.
    void OnCollisionEnter2D(Collision2D col)
    {
     // bump = collisionInfo.Gluttony.tag;
        if (col.transform.name == "wallRight" || col.transform.name == "wallLeft")
            direction.x *= -1;
    }
}
