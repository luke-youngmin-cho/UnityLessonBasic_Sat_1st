using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    static public GamePlay instance;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> players = new List<GameObject>();
    private List<Transform> finishedPlayers = new List<Transform>();
    public List<Transform> platforms = new List<Transform>();

    private int totalPlayers;
    private float playerStartZPos;
    public Transform goal;
    public bool onPlay = false;

    private void Start()
    {
        totalPlayers = players.Count;
    }
    // Update is called once per frame
    void Update()
    {
        if (onPlay)
        {
            CheckPlayerReachedToGoalAndStopMove();
            CheckGameIsFinished();
        }
    }
    void CheckPlayerReachedToGoalAndStopMove()
    {
        for(int i = players.Count - 1; i > -1 ; i--)
        {
            PlayerMove playerMove = players[i].GetComponent<PlayerMove>();
            if (playerMove.distance > goal.position.z - playerStartZPos)
            {
                playerMove.doMove = false;
                finishedPlayers.Add(players[i].transform);
                players.Remove(players[i]);
            }
        }
    }
    void CheckGameIsFinished()
    {
        if(finishedPlayers.Count >= totalPlayers)
        {
            onPlay = false;
            for (int i = 0; i < platforms.Count; i++)
            {
                finishedPlayers[i].position = platforms[i].Find("PlayerPoint").position +
                                              new Vector3(0, finishedPlayers[i].lossyScale.y,0);  
            }
        }
    }
    public void PlayGame()
    {
        onPlay = true;
        playerStartZPos = players[0].transform.position.z;
        foreach (var sub in players)
        {
            PlayerMove playerMove = sub.GetComponent<PlayerMove>();
            if (playerMove != null)
                playerMove.doMove = true;
        }
    }
}
