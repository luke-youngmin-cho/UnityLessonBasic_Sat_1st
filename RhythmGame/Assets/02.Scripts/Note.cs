using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public KeyCode keyCode;
    public float speed = 1f;
    Transform tr;

    //====================================================
    //****************** Public Methods ******************
    //====================================================

    public void Hit(HitType hitType)
    {
        switch (hitType)
        {
            case HitType.Bad:
                break;
            case HitType.Miss:
                break;
            case HitType.Good:
                // todo -> 점수 증가
                break;
            case HitType.Great:
                // todo -> 점수 증가
                break;
            case HitType.Cool:
                // todo -> 점수 증가
                break;
            default:
                break;
        }
        // todo -> 히트타입 팝업 UI On
    }

    //====================================================
    //****************** Private Methods *****************
    //====================================================

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        tr.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }
    
}

public enum HitType
{
    Bad,
    Miss,
    Good,
    Great,
    Cool
}