using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Rigidbody2D myRigidBody;
    //[SerializeField] private float speed = 20f;
    //[SerializeField] private bool startMoving = false;
    //Vector2 clickPosition;
    public Transform Arrow;
    void Start()
    {
        
    }


    /*void Update()
    {
         ArrowRotation();
        PlayerVeclocity();

    }

    void PlayerVeclocity()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (clickPosition - transform.position).normalized;
            myRigidBody.velocity = moveDirection * speed;
        }
    }

    void ArrowRotation()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 arrowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Arrow.LookAt(arrowPos, new Vector3(0, 0, 1));
        }
    }*/

    

    public void VelocityOnClick(Vector2 velocity)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = velocity;       
    }
    public void VelocityOnCollision(Vector2 velocity)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity += velocity;


    }
    
}

