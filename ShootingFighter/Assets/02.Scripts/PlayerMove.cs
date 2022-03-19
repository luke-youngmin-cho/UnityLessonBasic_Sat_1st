using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 키보드 화살표 왼쪽,오른쪽 방향키로 X 축으로 움직임
    // 키보드 화살표 위쪽,아랫쪽 방향키로 Z 축으로 움직임
    Transform tr;
    Vector3 move;
    public float speed = 1f;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        move = new Vector3(h, 0, v);
    }
    private void FixedUpdate()
    {
        tr.Translate(move * speed * Time.fixedDeltaTime);
    }
}
