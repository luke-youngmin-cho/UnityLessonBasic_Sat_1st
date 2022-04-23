using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;   
    private GroundDetector groundDetector;
    public bool invisiable; // 무적
    public float jumpForce;
    public float moveSpeed;
    private float moveInputOffset = 0.1f;
    Vector2 move;
    bool isMoveable = true;

    int _direction; // + 1 : right, - 1 : left
    public int direction
    {
        set
        {
            if (value < 0)
            {
                _direction = -1;
                transform.eulerAngles = new Vector3(0, 180f, 0);
            }
            else if (value > 0)
            {
                _direction = 1;
                transform.eulerAngles = Vector3.zero;
            }
        }
        get { return _direction; }
    }

    public PlayerState state;
    public IdleState idleState;
    public RunState runState;
    public JumpState jumpState;
    public FallState fallState;
    public AttackState attackState;
    public DashAttackState dashAttackState;
    public HurtState hurtState;
    public DieState dieState;

    [Header("애니메이션")]
    private Animator animator;
    private float animationTimer;
    private float attackTime;
    private float dashAttackTime;
    private float jumpCastingTime = 0.1f;
    private float jumpCastingTimer;
    private float hurtTime;
    private float dieTime;

    [Header("Physics")]
    public Vector2 attackBoxCastCenter;
    public Vector2 attackBoxCastSize;
    public float attackKnockbackForce;
    public float attackKnockbackTime;
    RaycastHit2D[] hits; // 타겟들


    public LayerMask enemyLayer;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundDetector = GetComponent<GroundDetector>();
        // initialize animations time
        attackTime = GetAnimationTime("Attack");
        dashAttackTime = GetAnimationTime("DashAttack");
        hurtTime = GetAnimationTime("Hurt");
        dieTime = GetAnimationTime("Die");
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        // 방향전환
        if (h < 0) direction = -1;
        else if (h > 0) direction = 1;

        if (isMoveable)
        {
            if (Mathf.Abs(h) > moveInputOffset)
            {
                move.x = h;
                if (state == PlayerState.Idle)
                    ChangePlayerState(PlayerState.Run);
            }
            else
            {
                move.x = 0;
                if (state == PlayerState.Run)
                    ChangePlayerState(PlayerState.Idle);
            }
        }
        

        // 점프 키
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (groundDetector.isDetected &&
               state != PlayerState.Jump &&
               state != PlayerState.Fall)
            {
                ChangePlayerState(PlayerState.Jump);
            }
        }

        // 공격 키
        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            if (state != PlayerState.Attack &&
                state != PlayerState.DashAttack)
                ChangePlayerState(PlayerState.Attack);
        }

        // 대시공격키
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (state != PlayerState.Attack &&
                state != PlayerState.DashAttack)
                ChangePlayerState(PlayerState.DashAttack);
        }

        UpdatePlayerState();
    }

    private void FixedUpdate()
    {
        rb.position += new Vector2(move.x * moveSpeed, move.y) * Time.fixedDeltaTime;
    }

    public void ChangePlayerState(PlayerState newState)
    {
        if (state == newState) return;

        // 이전 상태 하위 머신 초기화
        switch (state)
        {
            case PlayerState.Idle:
                idleState = IdleState.Idle;
                break;
            case PlayerState.Run:
                runState = RunState.Idle;
                break;
            case PlayerState.Jump:
                jumpState = JumpState.Idle;
                break;
            case PlayerState.Fall:
                fallState = FallState.Idle;
                break;
            case PlayerState.Attack:
                attackState = AttackState.Idle;
                break;
            case PlayerState.DashAttack:
                dashAttackState = DashAttackState.Idle;
                break;
            case PlayerState.Hurt:
                hurtState = HurtState.Idle;
                break;
            case PlayerState.Die:
                dieState = DieState.Idle;
                break;
            default:
                break;
        }

        // 현재 상태 바꿈
        state = newState;

        // 현재 상태 하위 머신 준비
        switch (state)
        {
            case PlayerState.Idle:
                idleState = IdleState.Prepare;
                break;
            case PlayerState.Run:
                runState = RunState.Prepare;
                break;
            case PlayerState.Jump:
                jumpState = JumpState.Prepare;
                break;
            case PlayerState.Fall:
                fallState = FallState.Prepare;
                break;
            case PlayerState.Attack:
                attackState = AttackState.Prepare;
                break;
            case PlayerState.DashAttack:
                dashAttackState = DashAttackState.Prepare;
                break;
            case PlayerState.Hurt:
                hurtState = HurtState.Prepare;
                break;
            case PlayerState.Die:
                dieState = DieState.Prepare;
                break;
            default:
                break;
        }

        if (newState != PlayerState.Fall)
            isMoveable = true;
    }

    private void UpdatePlayerState()
    {
        switch (state)
        {
            case PlayerState.Idle:
                UpdateIdleState();
                break;
            case PlayerState.Run:
                UpdateRunState();
                break;
            case PlayerState.Jump:
                UpdateJumpState();
                break;
            case PlayerState.Fall:
                UpdateFallState();
                break;
            case PlayerState.Attack:
                UpdateAttackState();
                break;
            case PlayerState.DashAttack:
                UpdateDashAttackState();
                break;
            case PlayerState.Hurt:
                UpdateHurtState();
                break;
            case PlayerState.Die:
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
                // 아무것도 안할거임.
                break;
            case IdleState.Finish:
                break;
            default:
                break;
        }
    }

    private void UpdateRunState()
    {
        switch (runState)
        {
            case RunState.Idle:
                break;
            case RunState.Prepare:
                animator.Play("Run");
                runState++;
                break;
            case RunState.Casting:
                runState++;
                break;
            case RunState.OnAction:
                break;
            case RunState.Finish:
                break;
            default:
                break;
        }
    }

    private void UpdateJumpState()
    {
        switch (jumpState)
        {
            case JumpState.Idle:
                break;
            case JumpState.Prepare:
                animator.Play("Jump");
                isMoveable = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCastingTimer = jumpCastingTime;
                jumpState++;
                break;
            case JumpState.Casting:
                if (!groundDetector.isDetected)
                    jumpState++;
                else if(jumpCastingTimer < 0)
                    ChangePlayerState(PlayerState.Idle);
                jumpCastingTimer -= Time.deltaTime;
                break;
            case JumpState.OnAction:
                if (rb.velocity.y < 0)
                    jumpState++;
                break;
            case JumpState.Finish:
                ChangePlayerState(PlayerState.Fall);
                break;
            default:
                break;
        }
    }

    private void UpdateFallState()
    {
        switch (fallState)
        {
            case FallState.Idle:
                break;
            case FallState.Prepare:
                animator.Play("Fall");
                fallState++;
                break;
            case FallState.Casting:
                fallState++;
                break;
            case FallState.OnAction:
                if (groundDetector.isDetected)
                    fallState++;
                break;
            case FallState.Finish:
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                
                break;
        }
    }

    private void UpdateAttackState()
    {
        switch (attackState)
        {
            case AttackState.Idle:
                break;
            case AttackState.Prepare:
                isMoveable = false;
                animator.Play("Attack");
                animationTimer = attackTime;
                attackState++;
                break;
            case AttackState.Casting:
                if (animationTimer < attackTime / 2)
                {
                    Vector2 tmpCenter = new Vector2(attackBoxCastCenter.x * direction, 
                                                    attackBoxCastCenter.y) 
                                                    + rb.position;

                    RaycastHit2D hit =  Physics2D.BoxCast(tmpCenter, 
                                                          attackBoxCastSize,
                                                          0, 
                                                          Vector2.zero, 
                                                          0, 
                                                          enemyLayer);
                    if (hit.collider != null)
                    {   
                        hit.collider.GetComponent<EnemyController>().Knockback(new Vector2(direction, 0),
                                                                               attackKnockbackForce,
                                                                               attackKnockbackTime);
                        hit.collider.GetComponent<Enemy>().hp -= 10;
                    }
                        
                    attackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case AttackState.OnAction:
                if (animationTimer < 0)
                {
                    attackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case AttackState.Finish:
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                break;
        }
    }

    private void UpdateDashAttackState()
    {
        switch (dashAttackState)
        {
            case DashAttackState.Idle:
                break;
            case DashAttackState.Prepare:
                isMoveable = false;
                animator.Play("DashAttack");
                animationTimer = dashAttackTime;

                // 적 캐스팅
                Vector2 tmpCenter = new Vector2(attackBoxCastCenter.x * direction,
                                                    attackBoxCastCenter.y)
                                                    + rb.position;

                hits = Physics2D.BoxCastAll(tmpCenter,
                                            attackBoxCastSize,
                                            0,
                                            Vector2.zero,
                                            1,
                                            enemyLayer);


                dashAttackState++;
                break;
            case DashAttackState.Casting:
                if (animationTimer < dashAttackTime * 2 / 3)
                {
                    foreach (var hit in hits)
                    {
                        if (hit.collider != null)
                        {
                            hit.collider.GetComponent<EnemyController>().Knockback(new Vector2(direction, 0),
                                                                                   attackKnockbackForce,
                                                                                   attackKnockbackTime);
                            hit.collider.GetComponent<Enemy>().hp -= 10;
                        }
                    }

                    move.x = 0;
                    dashAttackState++;
                }
                else
                {
                    move.x = direction * 3f;
                    animationTimer -= Time.deltaTime;
                }   
                break;
            case DashAttackState.OnAction:
                
                if (animationTimer < 0)
                {
                    dashAttackState++;
                }
                else
                    animationTimer -= Time.deltaTime;
                break;
            case DashAttackState.Finish:
                ChangePlayerState(PlayerState.Idle);
                break;
            default:
                break;
        }
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
                ChangePlayerState(PlayerState.Idle);
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
                dieState++;
                break;
            case DieState.Finish:
                // do nothing.
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

    public void Knockback(Vector2 forceVec, float time)
    {
        if (invisiable == false &&
            (state == PlayerState.Idle || 
             state == PlayerState.Run ||
             state == PlayerState.Jump ||
             state == PlayerState.Fall))
        {
            invisiable = true;
            Invoke("InvisiableOff", 1f);
            //StartCoroutine(E_InvisiableOff());
            rb.velocity = Vector2.zero;
            StartCoroutine(E_Knockback(forceVec, time));
        }
    }

    IEnumerator E_Knockback(Vector2 forceVec, float time)
    {
        float timer = time;
        while (timer > 0)
        {
            rb.AddForce(forceVec, ForceMode2D.Force);
            timer -= Time.deltaTime;
            yield return null; // 프레임 대기
        }
    }

    /*IEnumerator E_InvisiableOff()
    {
        yield return new WaitForSeconds(1f);
        invisiable = false;
    }*/

    void InvisiableOff()
    {
        invisiable = false;
    }

    private void OnDrawGizmos()
    {
        rb = GetComponent<Rigidbody2D>();
        Gizmos.color = Color.red;
        Vector2 tmpCenter = new Vector2(attackBoxCastCenter.x * direction, attackBoxCastCenter.y) + rb.position;
        Gizmos.DrawWireCube(tmpCenter, attackBoxCastSize);
    }


    public enum IdleState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    public enum RunState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum JumpState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum FallState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum AttackState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum DashAttackState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    public enum HurtState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    
    public enum DieState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
}

public enum PlayerState
{
    Idle, 
    Run,
    Jump,
    Fall,
    Attack,
    DashAttack,
    Hurt,
    Die,
}

