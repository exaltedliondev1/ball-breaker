using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Board : MonoBehaviour
{
    public static Board Instance;
    public Transform[] tiles;
    //public GameObject[] powerUps;
    public TileObject[] tileObjects;

    private void Awake()
    {
        Instance = this;
    }



    private void Start()
    {
        string filePath = "Assets/Resources/File.txt";
        StreamReader reader = new StreamReader(filePath);
        string Objdata = reader.ReadToEnd();
        reader.Close();
        tileObjects = JsonHelper.FromJson<TileObject>(Objdata);
        for (int i = 0; i < tileObjects.Length; i++)
        {
            GameObject tileObject = tileObjects[i].childObject;
            GameObject tilechildren = Instantiate(tileObject, tiles[i].transform.position, Quaternion.identity);
            tilechildren.transform.parent = tiles[i];

        }


       // for (int i = 0; i < tiles.Length; i++)
        //{
            




            // int j = Random.Range(0, powerUps.Length);
            //GameObject powObj = Instantiate(powerUps[j], tiles[i].transform.position, Quaternion.identity);
            //powObj.transform.parent = tiles[i];

        //}
    }


    public void MoveGrid()
    {
        for(int i =0; i<tiles.Length;i++)
        {
            tiles[i].transform.position = new Vector3(tiles[i].transform.position.x, tiles[i].transform.position.y-0.45f, tiles[i].transform.position.z);
        }
    }
    //int row;
    //int col;
    public void DecreseVerticallyHorizontallyHealth(GameObject obj)
    {
        Tile tile = obj.transform.GetComponentInParent<Tile>();
        int row = tile.row;
        int col = tile.col;
        DecreaseHealthInRow(row);
        DecreaseHealthInColumn(col);

    }


    public void DecreaseVerticallyHealth(GameObject obj)
    {
        Tile tile = obj.transform.GetComponentInParent<Tile>();
        int c = tile.col;
        DecreaseHealthInColumn(c);
    }

    public void DecreaseHorizontallyHealth(GameObject obj)
    {
        Tile tile = obj.transform.GetComponentInParent<Tile>();
        int r = tile.row;
        DecreaseHealthInRow(r);
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