using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelGenerator : MonoBehaviour
{
    public Transform[] tiles;
    public GameObject[] powerUps;
    public List<TileObject> tileObjects = new List<TileObject>();
    public TileObject[] tileObjarray;
    public string Tiledata;
    public GameObject blockPrefab;

  

    public void SelectSquare()
    {
        blockPrefab = powerUps[2];
    }

    public void SelectTriangle()
    {
        blockPrefab = powerUps[3];
    }

    public void SelectTriangle180()
    {
        blockPrefab = powerUps[4];
    }

    public void SelectHorizontal()
    {
        blockPrefab = powerUps[0];
    }

    public void SelectVertical()
    {
        blockPrefab = powerUps[5];
    }
    
    public void SelectAddBall()
    {
        blockPrefab = powerUps[1];
    }

    public void OnGenerate()
    {

        foreach (var tile in tiles)
        {
            Tile stile = tile.GetComponent<Tile>();
            //TileObject tileObject = new TileObject(stile.childObject);
            //tileObjects.Add(tileObject);
        }

        tileObjarray = tileObjects.ToArray();
        Tiledata = JsonHelper.ToJson(tileObjarray);
        string filePath = "Assets/Resources/File.txt";
        StreamWriter writer = new StreamWriter(filePath, false);
        writer.Write(Tiledata);
        writer.Close();
    }
}
