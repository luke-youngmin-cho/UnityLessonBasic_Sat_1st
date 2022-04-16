using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("현재 상태")]
    public EnemyState state;
    public IdleState idleState;
    public MoveState moveState;
    public AttackState attackState;
    public HurtState hurtState;
    public DieState dieState;

    [Header("애니메이션")]
    Animator animator;
    float animationTimer;
    float attackTime;
    float hurtTime;
    float dieTime;

    [Header("Kinematics")]
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        attackTime = GetAnimationTime("Attack");
        hurtTime = GetAnimationTime("Hurt");
        dieTime = GetAnimationTime("Die");
    }
    public void Knockback(Vector2 dir, float force, float time)
    {
        rb.velocity = Vector2.zero;
        StartCoroutine(E_Knockback(dir, force, time));
    }

    IEnumerator E_Knockback(Vector2 dir, float force, float time)
    {
        float timer = time;
        while (timer > 0)
        {
            rb.AddForce(dir * force, ForceMode2D.Force);
            timer -= Time.deltaTime;
            yield return null; // 프레임 대기
        }
    }


    private void Update()
    {
        UpdateEnemyState();
    }

    private void UpdateEnemyState()
    {
        switch (state)
        {
            case EnemyState.Idle:
                UpdateIdleState();
                break;
            case EnemyState.Move:
                UpdateMoveState();
                break;
            case EnemyState.Attack:
                UpdateAttackState();
                break;
            case EnemyState.Hurt:
                UpdateHurtState();
                break;
            case EnemyState.Die:
                UpdateDieState();
                break;
            default:
                break;
        }
    }

    private void UpdateIdleState()
    {
        switch (idleState)
        {
            case IdleState.Idle:
                break;
            case IdleState.Prepare:
                animator.Play("Idle");
                idleState++;
                break;
            case IdleState.Casting:
                idleState++;
                break;
            case IdleState.OnAction:
                // 아무것도 안함
                break;
            case IdleState.Finish:
                break;
            default:
                break;
        }
    }

    private void UpdateMoveState()
    {
        switch (moveState)
        {
            case MoveState.Idle:
                break;
            case MoveState.Prepare:
                animator.Play("Move");
                moveState++;
                break;
            case MoveState.Casting:
                moveState++;
                break;
            case MoveState.OnAction:
                // 아무것도 안함
                break;
            case MoveState.Finish:
                break;
            default:
                break;
        }
    }

    private void UpdateAttackState()
    {

    }

    private void UpdateHurtState()
    {
        switch (hurtState)
        {
            case HurtState.Idle:
                break;
            case HurtState.Prepare:
                animator.Play("Hurt");
                animationTimer = hurtTime;
                hurtState++;
                break;
            case HurtState.Casting:
                hurtState++;
                break;
            case HurtState.OnAction:
                if (animationTimer < 0)
                    hurtState++;
                else
                    animationTimer -= Time.deltaTime;
                break;
            case HurtState.Finish:
                ChangeEnemyState(EnemyState.Idle);
                break;
            default:
                break;
        }
    }

    private void UpdateDieState()
    {
        switch (dieState)
        {
            case DieState.Idle:
                break;
            case DieState.Prepare:
                animator.Play("Die");
                animationTimer = dieTime;
                dieState++;
                break;
            case DieState.Casting:
                dieState++;
                break;
            case DieState.OnAction:
                if (animationTimer < 0)
                    dieState++;
                else
                    animationTimer -= Time.deltaTime;
                break;
            case DieState.Finish:
                ChangeEnemyState(EnemyState.Idle);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 에너미 상태를 바꾸는 함수
    /// 기존 하위상태 초기화하고, 새로운 상태를 위한 하위상태를 준비상태로 변경함.
    /// </summary>
    /// <param name="newState"> 바꾸고자하는 새로운 상태</param>
    private void ChangeEnemyState(EnemyState newState)
    {
        if (state == newState) return;

        // 이전상태 초기화
        switch (state)
        {
            case EnemyState.Idle:
                idleState = IdleState.Idle;
                break;
            case EnemyState.Move:
                moveState = MoveState.Idle;
                break;
            case EnemyState.Attack:
                attackState = AttackState.Idle;
                break;
            case EnemyState.Hurt:
                hurtState = HurtState.Idle;
                break;
            case EnemyState.Die:
                dieState = DieState.Idle;
                break;
            default:
                break;
        }

        // 상태 갱신
        state = newState;

        // 갱신된 상태의 하위상태 머신 준비
        switch (state)
        {
            case EnemyState.Idle:
                idleState = IdleState.Prepare;
                break;
            case EnemyState.Move:
                moveState = MoveState.Prepare;
                break;
            case EnemyState.Attack:
                attackState = AttackState.Prepare;
                break;
            case EnemyState.Hurt:
                hurtState = HurtState.Prepare;
                break;
            case EnemyState.Die:
                dieState = DieState.Prepare;
                break;
            default:
                break;
        }
    }

    private float GetAnimationTime(string name)
    {
        float time = 0f;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == name)
                time = ac.animationClips[i].length;
        }

        return time;
    }


    public enum IdleState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }

    public enum MoveState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }

    public enum AttackState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }

    public enum HurtState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }

    public enum DieState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }
}

public enum EnemyState
{
    Idle,
    Move,
    Attack,
    Hurt,
    Die,
}

