using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerUI : MonoBehaviour
{
    public static TowerUI instance;

    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject sellButton;
    [SerializeField] private Text upgradePriceText;
    [SerializeField] private Text sellPriceText;

    private Node _node;
    private float _offsetY = 1f;
    private Color _textColorOrigin;

    public void Upgrade()
    {
        // 다음 레벨 타워 가져옴
        if (TowerAssets.TryGetTowerPrefab(_node.towerInfo.type,
                                          _node.towerInfo.upgradeLevel + 1,
                                          out GameObject towerPrefab))
        {
            _node.DestroyTower(); // 기존타워 파괴
            _node.BuildTower(towerPrefab); // 다음 레벨 타워 건설
            LevelManager.instance.money -= towerPrefab.GetComponent<Tower>().info.buildPrice;
        }
        Clear();
    }

    public void Sell()
    {
        LevelManager.instance.money += _node.towerInfo.sellPrice;
        _node.DestroyTower();
        Clear();
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;

        _textColorOrigin = upgradePriceText.color;
        Clear();
    }

    public void SetUp(Vector3 position, Node node)
    {
        _node = node;

        // 위치 세팅
        transform.position = position + Vector3.up * _offsetY;

        // 업그레이드 버튼 세팅
        if (TowerAssets.TryGetTowerPrefab(_node.towerInfo.type, _node.towerInfo.upgradeLevel + 1, out GameObject towerPrefab))
        {
            int upgradePrice = towerPrefab.GetComponent<Tower>().info.buildPrice;
            
            // 업그레이드 가능하지 않으면 텍스트 빨갛게, 상호작용 불가능하게 함
            if (upgradePrice > LevelManager.instance.money)
            {
                upgradePriceText.color = Color.red;
                upgradeButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                upgradePriceText.color = _textColorOrigin;
                upgradeButton.GetComponent<Button>().interactable = true;
            }

            upgradePriceText.text = upgradePrice.ToString();
            upgradeButton.SetActive(true);
        }
        else
        {
            upgradeButton.SetActive(false);
        }

        // 팔기 버튼 세팅
        sellPriceText.text = _node.towerInfo.sellPrice.ToString();

        gameObject.SetActive(true);
    }

    public void Clear()
    {
        _node = null;             
        upgradePriceText.text = "";
        sellPriceText.text = "";
        gameObject.SetActive(false);
    }
}
