
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
    public static DicePlayManager instance;

    private int currentTileIndex; // 현재 칸 인덱스
    private int _diceNum; // 남은 주사위 총 갯수
    public int diceNum
    {
        set
        {
            if(value >= 0) // 남은 주사위 갯수를 0 이상으로만 셋 가능
            {
                _diceNum = value;
                diceText.text = _diceNum.ToString(); // Text 업데이트
            }
        }
        get
        {
            return _diceNum;
        }
    }
    public Text diceText; // 남은 주사위 갯수 텍스트UI 
    public int diceNumInit; // 주사위 초기값

    private int _goldenDiceNum; // 황금 주사위 남은갯수
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
            return _starScore;
        }
    }
    public Text starScoreText;

    // 1 : forward, -1: backward
    private int _direction;
    public int direction
    {
        set
        {
            _direction = value;
            if (_direction > 0)
                inversePanel.SetActive(false);
            else
                inversePanel.SetActive(true);
        }
        get
        {
            return _direction;
        }
    }
    public GameObject inversePanel;

    
    public List<Transform> mapTiles;

    public Coroutine animationCoroutine = null;
    private void Awake()
    {
        instance = this;
        diceNum = diceNumInit; 
        goldenDiceNum = goldenDiceNumInit;
        starScore = 0;
    }

    public void RollADice()
    {
        if (diceNum < 1) return;
        if (animationCoroutine != null) return;

        diceNum--;
        int diceValue = Random.Range(1, 7);
        animationCoroutine = StartCoroutine(DiceAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer));
    }

    public void RollAGoldenDice(int diceValue)
    {
        if (goldenDiceNum < 1) return;
        if (animationCoroutine != null) return;

        goldenDiceNum--;
        animationCoroutine = StartCoroutine(DiceAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer));
    }

    private void MovePlayer(int diceValue)
    {
        int previousTileIndex = currentTileIndex;
        currentTileIndex += diceValue * direction;

        CheckPlayerPassedStarTile(previousTileIndex, currentTileIndex);

        if (currentTileIndex >= mapTiles.Count)
            currentTileIndex -= mapTiles.Count;

        Player.instance.Move(GetTilePosition(currentTileIndex));
        direction = 1;

        mapTiles[currentTileIndex].GetComponent<TileInfo>().TileEvent();        
    }

    private void CheckPlayerPassedStarTile(int previousIndex, int currentIndex)
    {
        for (int i = previousIndex + 1; i <= currentIndex; i++)
        {
            int tmpIndex = i;
            if (tmpIndex >= mapTiles.Count)
                tmpIndex -= mapTiles.Count;

            if (mapTiles[tmpIndex].TryGetComponent(out TileInfo_Star tmpStarTile))
                starScore += tmpStarTile.starValue;
        }
    }


    private Vector3 GetTilePosition(int tileIndex)
    {
        return mapTiles[tileIndex].position;
    }

}
