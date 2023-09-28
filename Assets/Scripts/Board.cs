using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    public static Board Instance;
    public Transform[] tiles;
    public GameObject[] powerUps;
    public TileObject[] tileObjects;
    public int[] tilePrefabIndex;
    public string levelstring;
    public int counter;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public int totalTilesNull;



    private void Awake()
    {
        Instance = this;
    }



    private void Start()
    {
        
        levelstring = DataManger.Instance.index.ToString();
       
            string filePath = "Assets/Resources/File" + levelstring + ".txt";
            StreamReader reader = new StreamReader(filePath);
            string Objdata = reader.ReadToEnd();
            reader.Close();
            tileObjects = JsonHelper.FromJson<TileObject>(Objdata);
            for (int i = 0; i < tileObjects.Length; i++)
            {
                if (tileObjects[i].isfilled)
                {
                    GameObject powObj = Instantiate(powerUps[tileObjects[i].childindex], tiles[i].transform.position, Quaternion.identity);
                    powObj.transform.parent = tiles[i];
                }


            }



    }

    private void Update()
    {
        if (counter == 6)
        {
            BallManager.Instance.clickEnable = false;
            GameOverPanel();
        }
        WinPanel();
    }

    public void WinPanel()
    {
        foreach(Transform tile in tiles)
        {
            if(tile.childCount == 0)
            {
                totalTilesNull++;
            }
            else
            {
                totalTilesNull = 0;
                break;
                
            }
        }

        if(totalTilesNull== tiles.Length)
        {
            winPanel.SetActive(true);
        }
    }

    public void GameOverPanel()
    {                   
           gameOverPanel.SetActive(true);
           counter = 0;       
    }

    public void MoveGrid(int counter)
    {
        this.counter += counter;
        for(int i =0; i<tiles.Length;i++)
        {
            tiles[i].transform.position = new Vector3(tiles[i].transform.position.x, tiles[i].transform.position.y-0.45f, tiles[i].transform.position.z);
        }
    }

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



    public void Replay()
    {
        BallManager.Instance.clickEnable = true;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);       
    }

    public void MainMenu()
    {
        BallManager.Instance.clickEnable = true;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        BallManager.Instance.clickEnable = true;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        DataManger.Instance.index++;
        if (DataManger.Instance.index < DataManger.Instance.noOflevels)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
       
    }
}
