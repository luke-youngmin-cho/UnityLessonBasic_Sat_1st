using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int index;
    public void TileEvent()
    {
        Debug.Log($"index of this tile : {index}");
    }
}
