using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyBodyBitsPlugins : MonoBehaviour
{
    public float Damage = 10f;
    public float fireRate = 0f;
    public LayerMask notToHit;

    float timeToFire = 0;
    Transform firePoint;

    //Use this for initialization
    void Awake ()
    {
        firePoint = transform.Find ("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint? WHAT!?");
        }
    }
    //Update is caleld once per frame
    void Update ()
    {
        if (fireRate == 0)
        {
            if (Input.GetKeyDown (KeyCode.Alpha1))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    void Shoot () {
      }
}