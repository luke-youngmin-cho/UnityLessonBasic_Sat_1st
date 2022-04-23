using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyController controller;

    public EnemyUI ui;
    public float hpMax = 100;
    private float _hp;
    public float hp
    {
        set
        {
            if (value > 0 && value < hpMax)
            {
                controller.ChangeEnemyState(EnemyState.Hurt);
            }
            else if (value <= 0)
            {
                controller.ChangeEnemyState(EnemyState.Die);
                value = 0;
            }

            _hp = value;
            ui.SetHPBar(_hp / hpMax);
        }

        get
        {
            return _hp;
        }
    }

    public float damage = 20;
    public Vector2 knockbackForce;
    public float knockbackTime;
    private void Awake()
    {
        controller = GetComponent<EnemyController>();
        hp = hpMax;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // 플레이어넉백
            collision.gameObject.GetComponent<PlayerController>().Knockback(new Vector2(knockbackForce.x * controller.direction, knockbackForce.y),
                                                                            knockbackTime);
            collision.gameObject.GetComponent<Player>().hp -= damage;
        }
    }
}
