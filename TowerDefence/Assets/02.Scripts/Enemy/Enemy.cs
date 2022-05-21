using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    private float _hp;
    public float hp
    {
        set
        {
            if (value < 0)
                value = 0;

            _hp = value;
            hpBar.value = _hp / hpMax;

            Destroy(gameObject);
        }

        get
        {
            return _hp;
        }
    }
    public float hpMax;
    [SerializeField] private Slider hpBar;

    private void Awake()
    {
        hp = hpMax;
    }
}
