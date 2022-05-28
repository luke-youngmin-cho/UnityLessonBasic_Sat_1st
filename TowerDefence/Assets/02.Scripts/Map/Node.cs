using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float towerOffsetY;
    private Tower towerBuilt;
    private Renderer rend;
    private Color originColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;
    public TowerInfo towerInfo
    {
        get
        {
            return towerBuilt.info;
        }
    }

    public void BuildTower(GameObject towerPrefab)
    {
        towerBuilt = Instantiate(towerPrefab,
                                 transform.position + Vector3.up * towerOffsetY,
                                 Quaternion.identity,
                                 transform).GetComponent<Tower>();
    }

    public void DestroyTower()
    {
        Destroy(towerBuilt.gameObject);
        towerBuilt = null;
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (TowerHandler.instance.isSelected)
        {
            TowerHandler.instance.transform.position = transform.position + Vector3.up * towerOffsetY;


            if (towerBuilt == null)
            {
                rend.material.color = buildAvailableColor;
            }
            else
            {
                rend.material.color = buildNotAvailableColor;
            }
            
        }
    }

    private void OnMouseDown()
    {
        // 건설할 타워가 선택되었고, 현재 노드에 건설된 타워가 없다면 타워 건설
        if (TowerHandler.instance.isSelected &&
            towerBuilt == null)
        {
            TowerInfo info = TowerHandler.instance.selectedTowerInfo;
            if (TowerAssets.TryGetTowerPrefab(info.type, info.upgradeLevel, out GameObject towerPrefab))
            {                
                BuildTower(towerPrefab);
                TowerHandler.instance.Clear();
            }
            else
            {
                throw new System.Exception("타워 프리팹 을 가져오는데 실패함. 타워 타입과 레벨 확인해주세요");
            }
        }
        else if (TowerHandler.instance.isSelected == false &&
                 towerBuilt != null)
        {
            TowerUI.instance.SetUp(towerBuilt.transform.position, this);
        }
    }

    private void OnMouseExit()
    {
        TowerHandler.instance.SendFar();   
        rend.material.color = originColor;
    }
}
