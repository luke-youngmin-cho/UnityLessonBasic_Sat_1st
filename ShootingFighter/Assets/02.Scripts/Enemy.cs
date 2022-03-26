using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject destroyEffect;
    public LayerMask targetLayer;
    public int damage;
    public int score;

    private int _hp;
    public int hp
    {
        set
        {
            if (value > 0)
                _hp = value;
            else
            {
                _hp = 0;
                Player.instance.score += score;
                DoDestroyEffect();
                Destroy(gameObject);
            }                

            hpSlider.value = (float)_hp / hpMax;
        }
        get
        {
            return _hp;
        }
    }
    public int hpMax;
    public Slider hpSlider;

    private void Awake()
    {
        hp = hpMax;
    }
    public void DoDestroyEffect()
    {
        GameObject go = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(go, 3);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {   
            Player.instance.hp -= damage;
            Destroy(gameObject);
        }
    }
}
