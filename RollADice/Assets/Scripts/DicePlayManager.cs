
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
    private int currentTileIndex;
    private int _diceNum;
    public int diceNum
    {
        set
        {
            if(value >= 0)
            {
                _diceNum = value;
                diceText.text = _diceNum.ToString();
            }
        }
        get
        {
            return _diceNum;
        }
    }
    public Text diceText;
    public int diceNumInit;

    private int _goldenDiceNum;
    public int goldenDiceNum
    {
        set
        {
            if(value >= 0)
            {
                _goldenDiceNum = value;
                goldenDiceNumText.text = _goldenDiceNum.ToString();
            }
        }
        get
        {
            return _goldenDiceNum;
        }
    }
    public Text goldenDiceNumText;
    public int goldenDiceNumInit;

    private int _starScore;
    public int starScore
    {
        set
        {
            if(starScore >= 0)
            {
                _starScore = value;
                starScoreText.text = _starScore.ToString();
            }
        }
        get
        {
            return starScore;
        }
    }
    public Text starScoreText;

    public List<Transform> mapTiles;

    private void Awake()
    {
        diceNum = diceNumInit;
        goldenDiceNum = goldenDiceNumInit;
    }

    public void RollADice()
    {
        if (diceNum < 1) return;

        diceNum--;
        int diceValue = Random.Range(1, 7);
        MovePlayer(diceValue);
    }

    private void MovePlayer(int diceValue)
    {
        currentTileIndex += diceValue;

        if (currentTileIndex >= mapTiles.Count)
            currentTileIndex -= mapTiles.Count;
                
        Player.instance.Move(GetTilePosition(currentTileIndex));
    }

    private Vector3 GetTilePosition(int tileIndex)
    {
        return mapTiles[tileIndex].position;
    }

}
