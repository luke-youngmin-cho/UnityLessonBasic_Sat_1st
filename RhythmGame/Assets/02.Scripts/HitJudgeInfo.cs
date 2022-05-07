using UnityEngine;

[CreateAssetMenu(menuName = "Hit Judge Info")]
public class HitJudgeInfo : ScriptableObject
{
    [Header("______Bad 판정 높이______")]
    public float hitJudgeHeight_Bad;
    [Header("______Miss 판정 높이______")]
    public float hitJudgeHeight_Miss;
    [Header("______Good 판정 높이______")]
    public float hitJudgeHeight_Good;
    [Header("______Greate 판정 높이______")]
    public float hitJudgeHeight_Great;
    [Header("______Cool 판정 높이______")]
    public float hitJudgeHeight_Cool;
}
