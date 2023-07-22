using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool isMoving = false;
    Rigidbody2D rigidbody;
    CircleCollider2D collider;
    

    private void Start()
    {
        //Invoke("Destry", 1);
    }

    void Destry() {
        Destroy(gameObject);
    }


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        if (isMoving) {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 0.1f)
            {
                isMoving = false;
                Destroy(this.gameObject);
            }
        }
    }


    Transform target;
    public void StartMoving(Transform target)
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        collider.enabled = false;
        this.target = target;
        isMoving = true;
    }

    public void VelocityOnClick(Vector2 direction)
    {
         
         rigidbody.velocity = direction;       
    }

    public void MoveRandomly(int x)
    {
        Debug.Log(rigidbody.velocity);
        rigidbody.velocity = new Vector2(rigidbody.velocity.x+x, rigidbody.velocity.y+x);
    }
    
}

