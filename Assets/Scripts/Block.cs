
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
    public int maxHealth;
    public int blockHealth;
    public Color[] colors;
    //public Color[] borderColors;
    public TextMesh healthText;
    public SpriteRenderer spriteRenderer;
    public GameObject prefab;
   // public SpriteRenderer borderRenderer;


     void Start()
    {
        healthText.text = blockHealth.ToString();
        spriteRenderer.color = colors[colors.Length - 1];
        //borderRenderer.color = borderColors[borderColors.Length - 1];

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            blockHealth--;
            healthText.text = blockHealth.ToString();
            if (blockHealth == 50)
            {
                spriteRenderer.color = colors[colors.Length - 1];
               // borderRenderer.color = borderColors[borderColors.Length - 1];
            }
            else if (blockHealth == 40)
            {             
                spriteRenderer.color = colors[colors.Length - 2];
                //borderRenderer.color = borderColors[borderColors.Length - 2];
            }
            else if (blockHealth == 30)
            {
               
                spriteRenderer.color = colors[colors.Length - 3];
              //  borderRenderer.color = borderColors[borderColors.Length - 3];
            }
            else if (blockHealth == 20)
            {
               
               spriteRenderer.color = colors[colors.Length - 4];
              // borderRenderer.color = borderColors[borderColors.Length - 4];
            }
            else if (blockHealth == 10)
            {
               
                spriteRenderer.color = colors[colors.Length - 5];
               // borderRenderer.color = borderColors[borderColors.Length - 5];
            }
            else if (blockHealth <= 0)
            {
                Destroy(prefab);
            }
            
           
        }
    }
    
}
