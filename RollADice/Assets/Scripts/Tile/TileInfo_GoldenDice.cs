using System;
using UnityEngine;
public class TileInfo_GoldenDice : TileInfo
{
    public override void TileEvent()
    {
        Debug.Log($"index of this tile : {index} , Increase golden dice num +1 ");
        DicePlayManager.instance.goldenDiceNum++;
    }
}