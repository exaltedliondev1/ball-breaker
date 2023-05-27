using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesCollision : MonoBehaviour
{
    public float maxForce = 2f;
    public float minForce = 2f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Ball colliderBall = other.transform.GetComponent<Ball>();
        if (colliderBall != null)
        {
            colliderBall.ForceOnCollision(new Vector2(Random.Range(minForce,maxForce),Random.Range(minForce,maxForce)));
        }      
    }
}
