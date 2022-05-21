using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewTowerAssets : MonoBehaviour
{
    private static PreviewTowerAssets _instance;
    public static PreviewTowerAssets instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<PreviewTowerAssets>("Assets/PreviewTowerAssets"));
            return _instance;
        }
    }

    public List<GameObject> previewTowers = new List<GameObject>();

    public static GameObject GetPreviewTower(TowerType towerType)
    {
        return instance.previewTowers.Find(x => x.GetComponent<PreviewTower>().type == towerType);
    }
}
