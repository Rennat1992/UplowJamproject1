using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGluttonyPatrol : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform groundDetection;

    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        int layer_mask = LayerMask.GetMask("GroundInfo");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 10f);
        if ((groundInfo.collider.gameObject.tag == "ground") == false){
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                } else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
 }
  