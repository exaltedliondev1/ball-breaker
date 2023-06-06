using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class square : MonoBehaviour
{
    public LayerMask surfaceLayer;
    RaycastHit2D hit;
    Vector2 reflection;
    public Transform target;
    private void Update()
    {
          hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, surfaceLayer);

             if (hit.collider != null)
             {
                Debug.Log(hit.transform.gameObject.name);
                reflection = Vector2.Reflect(transform.right, hit.normal);
                //Gizmos.DrawRay(hit.point, reflection * 10f);
              }    
    }
   
    private void OnDrawGizmos()
    {
        hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, surfaceLayer);

        if (hit.collider != null)
        {
            Debug.Log(hit.transform.gameObject.name);
            reflection = Vector2.Reflect(transform.right, hit.normal);
            //Gizmos.DrawRay(hit.point, reflection * 10f);
        }

        Gizmos.color = Color.red;
    Gizmos.DrawRay(transform.position, transform.right * 10f); // Change the distance as needed

    if (hit.collider != null)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(hit.point, reflection * 10f); // Change the distance as needed
    }
    }
 
}
