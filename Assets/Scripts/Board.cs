using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance;
    public Transform[] tiles;
    public GameObject[] powerUps;

    private void Awake()
    {
        Instance = this;
    }



    private void Start()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            int j = Random.Range(0, powerUps.Length);
            GameObject powObj = Instantiate(powerUps[j], tiles[i].transform.position, Quaternion.identity);
            powObj.transform.parent = tiles[i];
             
        }
    }


    public void MoveGrid()
    {
        for(int i =0; i<tiles.Length;i++)
        {
            tiles[i].transform.position = new Vector3(tiles[i].transform.position.x, tiles[i].transform.position.y-0.45f, tiles[i].transform.position.z);
        }
    }

    public void DecreseVerticallyHorizontallyHealth(GameObject obj)
    {
        Tile tile = obj.GetComponentInParent<Tile>();
        int row = tile.row;
        int col = tile.col;

        for (int i = 0; i < tiles.Length; i++)
        {
           int r = tiles[i].GetComponent<Tile>().row;
           int c = tiles[i].GetComponent<Tile>().col;
        }
    }
}
