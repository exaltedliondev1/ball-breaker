using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Ball colliderBall = other.transform.GetComponent<Ball>();
        if (colliderBall != null)
        {
            colliderBall.VelocityOnCollision(new Vector2(0, 0.5f));
        }
    }
}
