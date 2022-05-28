using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int level;
    public int money;
    private LevelInfo info;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;

        SetUp();
    }

    private void SetUp()
    {
        info = LevelInfoAssets.GetLevelInfo(level);
        money = info.initMoney;
    }
}
