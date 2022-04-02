using System;
using UnityEngine;
public class TileInfo_Dice : TileInfo
{
    public override void TileEvent()
    {
        Debug.Log($"index of this tile : {index} , Increase dice num +1 ");
        DicePlayManager.instance.diceNum++;
    }
}