using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectButton : MonoBehaviour
{
    [SerializeField] private TowerInfo towerInfo;

    public void OnClick()
    {
        if (towerInfo.buildPrice <= LevelManager.instance.money)
        {
            TowerHandler.instance.SetUp(towerInfo);
        }
        else
        {
            // todo -> µ· ºÎÁ· ÇÏ´Ù´Â ÆË¾÷Ã¢ ¶ç¿ì±â
        }
           
    }

}
