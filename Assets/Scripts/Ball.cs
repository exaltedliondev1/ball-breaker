using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool isMoving = false;
    Rigidbody2D rigidbody;
    CircleCollider2D collider;
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

    public void VelocityOnClick(Vector2 velocity)
    {
         rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = velocity;       
    }
    public void ForceOnCollision(Vector2 velocity)
    {
         rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(velocity);        

    }
    public void MoveTowardSpawnPos(Transform spawnPos)
    {
        transform.Translate(spawnPos.position * Time.deltaTime);
    }
    
}

