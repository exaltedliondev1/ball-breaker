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
    int row;
    int col;
    public void DecreseVerticallyHorizontallyHealth(GameObject obj)
    {
        Tile tile = obj.transform.GetComponentInParent<Tile>();
        this.row = tile.row;
        this.col = tile.col;
        DecreaseHealthInRow(row);
        DecreaseHealthInColumn(col);

    }

    public void DecreaseHealthInRow(int row)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            Block block = tiles[i].GetComponentInChildren<Block>();
            Tile tile = tiles[i].gameObject.GetComponent<Tile>();
            if (block != null && tile.row == row)
            {
                block.blockHealth--;
                block.healthText.text = block.blockHealth.ToString();
            }
        }
    }

    public void DecreaseHealthInColumn(int column)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            Block block = tiles[i].GetComponentInChildren<Block>();
            Tile tile = tiles[i].gameObject.GetComponent<Tile>();
            if (block != null && tile.col == column)
            {
                block.blockHealth--;
                block.healthText.text = block.blockHealth.ToString();
            }
        }
    }
}
// Each Block in tiles which have same row decrease--
// Each Block in tiles which have same col decrease--