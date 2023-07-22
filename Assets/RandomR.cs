using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomR : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            int r = Random.Range(10, 20);
            Ball balli = other.gameObject.GetComponent<Ball>();
            if (balli != null)
                balli.MoveRandomly(r);
        }
    }
}
