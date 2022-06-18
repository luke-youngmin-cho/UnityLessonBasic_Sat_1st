using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine_Attack : PlayerStateMachine
{
    public Weapon1 weapon1;

    private int maxCombo = 4;
    private int currentCombo = 0;
    private float combo0Time;
    private float combo1Time;
    private float combo2Time;
    private float combo3Time;
    private float combo4Time;
    public float comboTimer;
    private bool doCombo;

    private void Start()
    {
        
        combo0Time = playerAnimator.GetClipTime("Slash0");
        combo1Time = playerAnimator.GetClipTime("Slash1");
        combo2Time = playerAnimator.GetClipTime("Slash2");
        combo3Time = playerAnimator.GetClipTime("Slash3");
        combo4Time = playerAnimator.GetClipTime("Slash4");
        Debug.Log($"{combo0Time}, {combo1Time}, {combo2Time}, {combo3Time}, {combo4Time}");
    }
    public override PlayerState UpdateState()
    {
        PlayerState nextState = playerState;

        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                playerAnimator.SetTrigger("DoAttack");
                playerAnimator.SetBool("FinishAttack", false);
                comboTimer = GetComboTime(currentCombo);
                doCombo = false;
                state++;
                break;
            case State.OnDelay:
                if (playerAnimator.IsClipPlaying(GetAnimationName(currentCombo)))                    
                    state++;
                break;
            case State.Casting:
                weapon1.doCasting = true;
                state++;
                break;
            case State.OnAction:

                if (comboTimer < GetComboTime(currentCombo) - 0.1f &&
                    comboTimer > 0 &&
                    currentCombo < maxCombo &&
                    Input.GetKey(keyCode))
                {
                    doCombo = true;
                }

                if (comboTimer < 0.5f)
                {
                    if (doCombo)
                    {
                        state = State.Prepare;
                        currentCombo++;
                    }
                    else
                    {
                        playerAnimator.SetBool("FinishAttack", true);
                        weapon1.doCasting = false;
                        currentCombo = 0;
                        state++;
                    }
                    playerAnimator.SetInt("CurrentAttackCombo", currentCombo);
                }

                comboTimer -= Time.deltaTime;
                break;
            case State.Finish:
                nextState = PlayerState.Move;
                break;
            default:
                break;
        }

        return nextState;
    }

    private float GetComboTime(int combo)
    {
        switch (combo)
        {
            case 0:
                return combo0Time;
            case 1:
                return combo1Time;
            case 2:
                return combo2Time;
            case 3:
                return combo3Time;
            case 4:
                return combo4Time;
            default:
                return 0;
        }
    }

    private string GetAnimationName(int combo)
    {
        switch (combo)
        {
            case 0:
                return "Slash0";
            case 1:
                return "Slash1";
            case 2:
                return "Slash2";
            case 3:
                return "Slash3";
            case 4:
                return "Slash4";
            default:
                return string.Empty;
        }
    }
}
