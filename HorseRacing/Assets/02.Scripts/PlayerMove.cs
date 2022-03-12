using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float distance;
    public Vector3 dir = Vector3.forward;
    public float minSpeed;
    public float maxSpeed;
    public bool doMove;

    Vector3 move;
    // Start is called before the first frame update
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (doMove)
            Move();
    }
    private void Move()
    {
        float moveSpeed = Random.Range(minSpeed, maxSpeed);
        move = dir * moveSpeed * Time.fixedDeltaTime;
        tr.Translate(move);
        distance += move.z;
    }
}
