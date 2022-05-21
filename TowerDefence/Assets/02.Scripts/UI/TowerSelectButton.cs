using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectButton : MonoBehaviour
{
    [SerializeField] private TowerInfo towerInfo;

    public void OnClick()
    {
        TowerHandler.instance.SetUp(towerInfo);
    }
}
