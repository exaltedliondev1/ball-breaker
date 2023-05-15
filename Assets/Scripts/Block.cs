
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int maxHealth;
    public int blockHealth;
    public Color[] colors;
    public float minForce= 0.2f;
    public float maxForce= 0.5f;

     void Update()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (blockHealth <= 90)
        {
            SpriteRenderer spriteRenderer =this.GetComponent<SpriteRenderer>();
            spriteRenderer.color = colors[colors.Length - 1];

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            blockHealth--;
            Ball ball = other.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                ball.ForceOnCollision(new Vector2(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce)));
            }
        }
    }

}
