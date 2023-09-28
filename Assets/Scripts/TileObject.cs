using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileObject
{

    public int childindex;
    public bool isfilled;

    public TileObject(int childindex, bool isfilled)
    {

        this.childindex = childindex;
        this.isfilled = isfilled;
    }
}
