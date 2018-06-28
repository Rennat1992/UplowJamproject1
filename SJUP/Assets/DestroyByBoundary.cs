using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    void OnCollisionEnter2D(Collider other)
    {
        // Destroy everything that leaves the trigger
        Destroy(other.gameObject); 
    }
}