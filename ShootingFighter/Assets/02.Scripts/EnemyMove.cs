using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Vector3 dir = Vector3.back;
    public float speed = 1f;
    Transform tr;
    private void Awake() =>
        tr = GetComponent<Transform>();

    private void FixedUpdate() =>
        tr.Translate(dir * speed * Time.fixedDeltaTime);
}
