using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int row;
    public int col;
    public GameObject objectPrefab;
    public bool isfilled;
    public LevelGenerator levelGenerator;
    public GameObject childObject;
    public int index;

    private void OnMouseDown()
    {
        
        objectPrefab = levelGenerator.blockPrefab;
        index = levelGenerator.prefabNo;
        if (isfilled != true)
        {
            childObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            childObject.GetComponent<Collider2D>().enabled = false;
            childObject.transform.SetParent(transform);
            isfilled = true;
        }
        else if (isfilled == true)
        {
            isfilled = false;
            if (childObject != null)
            {
                Debug.Log("Hello");
                Destroy(childObject);
            }
        }
     
        
    }


   
    /*
*/
}
