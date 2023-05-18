using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Rigidbody2D myRigidBody;
    //[SerializeField] private float speed = 20f;
    //[SerializeField] private bool startMoving = false;
    //Vector2 clickPosition;
    
  

   

    

    public void VelocityOnClick(Vector2 velocity)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = velocity;       
    }
    public void ForceOnCollision(Vector2 velocity)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(velocity);        

    }
    public void MoveTowardSpawnPos(Transform spawnPos)
    {
        transform.Translate(spawnPos.position * Time.deltaTime);
    }
    
}

