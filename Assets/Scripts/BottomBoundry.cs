using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundry : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Ball balli = other.gameObject.GetComponent<Ball>();
            int ballcount = BallManager.Instance.detectBall++;
            
            
            Transform position = other.transform;
            BallManager.Instance.SetSpawnPosition(position);
            Destroy(other.gameObject);
            
            
        }
    }
}
