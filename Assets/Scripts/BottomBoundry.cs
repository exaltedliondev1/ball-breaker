using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundry : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Vector3 position = other.transform.position;
            
            
        }
    }
}
