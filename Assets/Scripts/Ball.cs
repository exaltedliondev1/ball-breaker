using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Rigidbody2D myRigidBody;
    //[SerializeField] private float speed = 20f;
    //[SerializeField] private bool startMoving = false;
    //Vector2 clickPosition;
    
    void Start()
    {
        
    }


   

    

    public void VelocityOnClick(Vector2 velocity)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = velocity;       
    }
    public void ForceOnCollision(Vector2 velocity)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(velocity);
        Debug.Log(velocity);
            


    }
    
}

