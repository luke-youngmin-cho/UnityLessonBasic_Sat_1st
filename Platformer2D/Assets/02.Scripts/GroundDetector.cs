using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isDetected
    {
        get
        {
            return detectedGround != null ? true : false;
        }
    }
    public Collider2D detectedGround;
    public Collider2D lastGround;
    public Collider2D ignoringGround;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private Vector2 size;
    private Vector2 center;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        size.x = col.size.x / 2;
        size.y = 0.005f;
    }

    private void Update()
    {
        center.x = rb.position.x + col.offset.x;
        center.y = rb.position.y + col.offset.y - col.size.y / 2 - size.y;
        detectedGround = Physics2D.OverlapBox(center, size, 0, groundLayer);
        if (detectedGround != null)
            lastGround = detectedGround;
    }

    public void IgnoreLastGroundUntilPassedIt()
    {
        ignoringGround = lastGround;
        if (ignoringGround != null)
            StartCoroutine(E_IgnoreGroundUntilPassedIt(ignoringGround));
    }

    IEnumerator E_IgnoreGroundUntilPassedIt(Collider2D groundCol)
    {
        Physics2D.IgnoreCollision(col, groundCol, true);
        float passingGroundColCenter = groundCol.transform.position.y + groundCol.offset.y;

        // 플레이어가 해당 그라운드를 지나가기 시작하는지 체크
        yield return new WaitUntil(() =>
        {
            return rb.position.y + col.offset.y - col.size.y / 2 < passingGroundColCenter;
        }
        );

        // 플레이어 해당 그라운드를 완전히 지나갔는지 체크
        yield return new WaitUntil(() =>
        {
            bool isPassed = false;

            if (groundCol != null)
            {
                // 지형이 이동할시를 대비해서 위치 계속 갱신함 
                passingGroundColCenter = groundCol.transform.position.y + groundCol.offset.y;

                // 플레이어가 지형을 통과했는지 체크 
                // 1. 플레이어가 떨어지면서 지형통과
                // 2. 플레이어가 올라가면서 지형통과
                if ((rb.position.y + col.offset.y + col.size.y / 2 < passingGroundColCenter - size.y) ||
                    (rb.position.y + col.offset.y - col.size.y / 2 > passingGroundColCenter + size.y))
                {
                    isPassed = true;
                }
            }
            // 지형이 사라졌을경우
            else
                isPassed = true;

            return isPassed;
        });

        Physics2D.IgnoreCollision(col, groundCol, false);
    }


    private void OnDrawGizmos()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        size.x = col.size.x / 2;
        size.y = 0.005f;
        center.x = rb.position.x + col.offset.x;
        center.y = rb.position.y + col.offset.y - col.size.y / 2 - size.y;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(center.x, center.y, 0),
                            new Vector3(size.x, size.y, 0));
    }
}
