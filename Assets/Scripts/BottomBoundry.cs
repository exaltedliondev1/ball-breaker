
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
            BallManager.Instance.SetSpawnPosition(other.gameObject);
            GameObject spawnPos = BallManager.Instance.spawnPos;
            balli.StartMoving(spawnPos.transform);
            //Destroy(other.gameObject);
        }
    }

   
}
