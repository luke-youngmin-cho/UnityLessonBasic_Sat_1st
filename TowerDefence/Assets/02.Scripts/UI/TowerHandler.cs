using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerHandler : MonoBehaviour
{
    public static TowerHandler instance;
    public GameObject preivewTower;

    public bool isSelected
    {
        get
        {
            return selectedTowerInfo != null ? true : false;
        }
    }
    private TowerInfo selectedTowerInfo;

    public void SetUp(TowerInfo towerInfo)
    {
        selectedTowerInfo = towerInfo;
        gameObject.SetActive(true);
        if (preivewTower != null)
            Destroy(preivewTower);
        preivewTower = Instantiate(PreviewTowerAssets.GetPreviewTower(selectedTowerInfo.type), transform);
    }

    public void Clear()
    {
        selectedTowerInfo = null;
        gameObject.SetActive(false);
        if (preivewTower != null)
            Destroy(preivewTower);
    }

    public void SendFar()
    {
        transform.position = new Vector3(5000f, 5000f, 5000f);
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
        gameObject.SetActive(false);
    }       
}
