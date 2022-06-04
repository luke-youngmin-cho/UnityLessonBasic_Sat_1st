using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{    
    public LayerMask touchLayer;
    public LayerMask targetLayer;
    public float explosionRange;
    public float speed;
    private float _damage;
    private Vector3 moveVec;
    private Transform tr;

    public void SetUp(Transform target, float damage)
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        moveVec = dir * speed;
        _damage = damage;
        transform.LookAt(target);
    }

    private void Awake()
    {
        tr = transform;
    }

    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, 1f, touchLayer);
        if (cols.Length > 0)
            Explode();
    }

    private void FixedUpdate()
    {
        tr.Translate(moveVec * Time.fixedDeltaTime, Space.World);
    }

    private void Explode()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, explosionRange, targetLayer);
        foreach (var col in cols)
        {
            col.GetComponent<Enemy>().hp -= _damage;
        }
        Destroy(gameObject);
    }

}
