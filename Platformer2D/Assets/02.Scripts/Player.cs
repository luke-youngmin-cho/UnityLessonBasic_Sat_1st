using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController controller;

    public bool invisiable; // 무적
    public float hpMax = 1000;
    private float _hp;
    public float hp
    {
        set
        {
            // hp 가 깎였을떄
            if (_hp > value)
            {
                // 무적상태면 체력 안깎음
                if (invisiable)
                    return;
                // 아니면 1초 무적
                invisiable = true;
                Invoke("InvisiableOff", 1f);
            }

            if (value > 0 && value < hpMax)
            {
                controller.ChangePlayerState(PlayerState.Hurt);
            }
            else if (value <= 0)
            {
                controller.ChangePlayerState(PlayerState.Die);
                value = 0;
            }

            _hp = value;
            if(PlayerUI.instance != null)
                PlayerUI.instance.SetHPBar(_hp / hpMax);
        }

        get
        {
            return _hp;
        }
    }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        hp = hpMax;
    }

    void InvisiableOff()
    {
        invisiable = false;
    }
}
