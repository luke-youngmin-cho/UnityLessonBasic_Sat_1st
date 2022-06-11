using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachineManager : MonoBehaviour
{
    public PlayerStateMachine_Jump jumpMachine;
    public PlayerState state;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&
            jumpMachine.isExecuteOK())
        {
            jumpMachine.Execute();
        }
        state = jumpMachine.UpdateState();
    }

    private void FixedUpdate()
    {
        jumpMachine.FixedUpdateState();
    }

}

public enum PlayerState
{
    Idle,
    Move,
    Jump,
    Attack,
}