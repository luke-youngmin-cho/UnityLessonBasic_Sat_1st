using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    public TowerInfo info;
    public LayerMask enemyLayer;
    public float detectRange;

    public Transform rotatePoint;
    public Transform target;

    protected Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    protected virtual void Update()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, detectRange, enemyLayer);

        if (cols.Length > 0)
        {
            cols.OrderBy(x => (x.transform.position - WayPoints.instance.GetLastWayPoint().position).magnitude);
            target = cols[0].transform;
            rotatePoint.LookAt(target);
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
