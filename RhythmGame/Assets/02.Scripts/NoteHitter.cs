using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NoteHitter : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private HitJudgeInfo hitJudgeInfo;
    [SerializeField] private LayerMask noteLayer;

    private SpriteRenderer icon;
    [SerializeField] private Color pressedColor;
    private Color originalColor;

    private void Awake()
    {
        icon = GetComponent<SpriteRenderer>();
        originalColor = icon.color;
    }

    private void Update()
    {
        // 키입력 들어올때 노트 히트
        if (Input.GetKeyDown(keyCode))
            TryHitNote();

        //if (Input.GetKeyDown(keyCode))
        //    TryHitPressingNote();

        // 눌려져있으면색바꿈
        if (Input.GetKey(keyCode))
            ChangeColor();
        else
            RollbackColor();
    }

    private void ChangeColor() =>
        icon.color = pressedColor;
    private void RollbackColor() =>
        icon.color = originalColor;

    private bool TryHitNote()
    {
        HitType hitType = HitType.Bad;

        List<Collider2D> overlaps =
            Physics2D.OverlapBoxAll(transform.position,
                                    new Vector2(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Bad),
                                    0, noteLayer).ToList();

        if (overlaps.Count > 0)
        {
            overlaps.OrderBy(x => Mathf.Abs(transform.position.y - x.transform.position.y));
            float distance = Mathf.Abs(transform.position.y - overlaps[0].transform.position.y);

            if (distance < hitJudgeInfo.hitJudgeHeight_Cool)
                hitType = HitType.Cool;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Great)
                hitType = HitType.Great;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Good)
                hitType = HitType.Good;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Miss)
                hitType = HitType.Miss;
            else
                hitType = HitType.Bad;

            overlaps[0].GetComponent<Note>().Hit(hitType);
            overlaps[0].gameObject.SetActive(false);
            return true;
        }
        return false;
    }


    private void OnDrawGizmos()
    {
        // Bad 판정 범위 기즈모
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Bad, 0));
        // Miss 판정 범위 기즈모
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Miss, 0));
        // Good 판정 범위 기즈모
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Good, 0));
        // Great 판정 범위 기즈모
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Great, 0));
        // Cool 판정 범위 기즈모
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,
                            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Cool, 0));
    }
}
