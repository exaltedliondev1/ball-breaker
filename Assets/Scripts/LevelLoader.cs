using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int index;
    public void SetLevelIndex()
    {
        DataManger.Instance.index = index;
        SceneManager.LoadScene(0);
    }
}
