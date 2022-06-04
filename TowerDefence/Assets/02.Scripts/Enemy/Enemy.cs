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

            if (_hp <= 0)
            {
                GameObject go = Instantiate(dieEffect.gameObject, transform.position, Quaternion.identity);
                Destroy(go, dieEffect.main.duration + dieEffect.main.startLifetime.constantMax);
                Destroy(gameObject);
            }   
        }

        get
        {
            return _hp;
        }
    }
    public float hpMax;
    [SerializeField] private Slider hpBar;
    [SerializeField] private ParticleSystem dieEffect;

    private void Awake()
    {
        hp = hpMax;
    }

}
