using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    public Transform[] tiles;
    public GameObject[] powerUps;
    public List<TileObject> tileObjects = new List<TileObject>();
    public TileObject[] tileObjarray;
    public string Tiledata;
    public GameObject blockPrefab;
    public int prefabNo;
    public InputField levelInput;
    public string levelFile;
    

  

    public void SelectSquare()
    {
        blockPrefab = powerUps[2];
        prefabNo = 2;
    }

    public void SelectTriangle()
    {
        blockPrefab = powerUps[3];
        prefabNo = 3;
    }

    public void SelectTriangle180()
    {
        blockPrefab = powerUps[4];
        prefabNo = 4;
    }

    public void SelectHorizontal()
    {
        blockPrefab = powerUps[0];
        prefabNo = 0;
    }

    public void SelectVertical()
    {
        blockPrefab = powerUps[5];
        prefabNo = 5;
    }
    
    public void SelectAddBall()
    {
        blockPrefab = powerUps[1];
        prefabNo = 1;
    }



    public void OnGenerate()
    {
        levelFile = levelInput.text;
        levelInput.text = "";
        foreach (var tile in tiles)
        {
            Tile stile = tile.GetComponent<Tile>();
            TileObject tileObject = new TileObject(stile.index, stile.isfilled);
            tileObjects.Add(tileObject);
        }

        tileObjarray = tileObjects.ToArray();
        Tiledata = JsonHelper.ToJson(tileObjarray);
        string filePath = "Assets/Resources/File"+levelFile+".txt";
        StreamWriter writer = new StreamWriter(filePath, false);
        writer.Write(Tiledata);
        writer.Close();
    }
}
// buttons hongy different ik scene me 
// Button click pr if it does not work then what to do 
// 