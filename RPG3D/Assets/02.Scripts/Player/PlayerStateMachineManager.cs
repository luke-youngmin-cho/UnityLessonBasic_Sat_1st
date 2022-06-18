using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachineManager : MonoBehaviour
{
    private Dictionary<PlayerState, PlayerStateMachine> machines = new Dictionary<PlayerState, PlayerStateMachine>();
    private Dictionary<KeyCode, PlayerState> machineKeyCodes = new Dictionary<KeyCode, PlayerState>();
    public PlayerState state;
    private PlayerStateMachine currentMachine;
    private KeyCode keyInput;

    private void Awake()
    {
        PlayerStateMachine[] playerStateMachines = GetComponents<PlayerStateMachine>();
        foreach (PlayerStateMachine playerStateMachine in playerStateMachines)
        {
            Debug.Log($"Added  machine {playerStateMachine.keyCode} {playerStateMachine.playerState}");
            machines.Add(playerStateMachine.playerState, playerStateMachine);
            if (playerStateMachine.keyCode != KeyCode.None)
                machineKeyCodes.Add(playerStateMachine.keyCode, playerStateMachine.playerState);
        }
        currentMachine = machines[PlayerState.Move];
        state = PlayerState.Move;
    }

    private void Update()
    {
        foreach (var sub in machineKeyCodes)
        {
            if (Input.GetKeyDown(sub.Key))
            {
                ChangePlayerState(sub.Value);
            }
        }

        ChangePlayerState(currentMachine.UpdateState());

        //if (keyInput != KeyCode.None)
        //{
        //    if (machineKeyCodes.TryGetValue(keyInput, out PlayerState tmpPlayerState))
        //    {
        //        ChangePlayerState(tmpPlayerState);
        //    }   
        //
        //    keyInput = KeyCode.None;
        //}
    }

    private void ChangePlayerState(PlayerState newState)
    {
        // 변경하려는 상태가 기존 상태와 같다면 바꾸지않음
        if (state == newState) return;

        // 변경하려는 머신이 동작가능하면
        if (machines[newState].isExecuteOK())
        {
            currentMachine.ForceStop(); // 현재 머신 강제중지
            currentMachine = machines[newState]; // 현재 머신 변경
            currentMachine.Execute(); // 현재 머신 실행
            state = newState; // 현재 상태 변경
        }
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if ((e.isKey || e.isMouse) &&
             e.keyCode != KeyCode.None)
        {
            keyInput = e.keyCode;
        }
    }

    private void FixedUpdate()
    {
    }

}

public enum PlayerState
{
    Idle,
    Move,
    Jump,
    Attack,
}