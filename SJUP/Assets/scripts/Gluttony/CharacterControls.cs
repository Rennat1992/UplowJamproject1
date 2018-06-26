﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [SerializeField]
public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }
    private float moveSpeed = 5f;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0F;

    private float nextFire = .25F;

    //To allow Player to shoot
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) { 
            nextFire = Time.time + fireRate;
 //           GameObject clone = 
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject
         }
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
        }
    }
}
