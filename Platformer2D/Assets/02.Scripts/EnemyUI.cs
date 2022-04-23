using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Slider hpBar;

    public void SetHPBar(float value) =>
        hpBar.value = value;
}
