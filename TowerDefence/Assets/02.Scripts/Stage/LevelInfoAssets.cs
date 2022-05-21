using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 레벨에 대한 정보 에셋을 가져다 쓰기위한 클래스
/// </summary>
public class LevelInfoAssets : MonoBehaviour
{
    private static LevelInfoAssets _instance;
    public static LevelInfoAssets instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<LevelInfoAssets>("Assets/LevelInfoAssets"));
            return _instance;
        }
    }

    public List<LevelInfo> levelInfos = new List<LevelInfo>();

    /// <summary>
    /// 특정 레벨의 특정 스테이지 정보를 반환함
    /// </summary>
    /// <param name="level"> 검색할 레벨 </param>
    /// <param name="stage"> 검색할 스테이지 </param>
    /// <returns></returns>
    public static StageInfo GetStageInfo(int level, int stage)
    {
        // 찾고자하는 레벨 정보 검색
        LevelInfo levelInfo = instance.levelInfos.Find(x => x.level == level);

        // 레벨 정보 검색 성공시
        if (levelInfo != null)
        {
            // 해당 레벨의 찾고자하는 스테이지 정보 검색
            return levelInfo.stageInfos.Find(x => x.stage == stage);
        }
        return null;
    }

    /// <summary>
    /// 특정 레벨의 모든 스테이지 정보를 반환
    /// </summary>
    /// <param name="level"> 검색할 레벨</param>
    /// <returns></returns>
    public static StageInfo[] GetAllStageInfo(int level)
    {
        // 찾고자하는 레벨 정보 검색
        LevelInfo levelInfo = instance.levelInfos.Find(x => x.level == level);

        // 레벨 정보 검색 성공시
        if (levelInfo != null)
        {
            return levelInfo.stageInfos.ToArray();
        }
        return null;
    }
}