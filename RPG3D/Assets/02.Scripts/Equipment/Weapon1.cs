using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : Equipment
{
    [SerializeField] private LayerMask targetLayer;
    private TrailRenderer trailRenderer;

    private bool _doCasting;
    public bool doCasting
    {
        set
        {
            if (value == false)
            {
                targets.Clear();
                if (trailRenderer != null)
                    trailRenderer.enabled = false;
            }
            else
            {
                if (trailRenderer != null)
                    trailRenderer.enabled = true;
            }
                
            _doCasting = value;
        }
    }

    Dictionary<int, GameObject> targets = new Dictionary<int, GameObject>();

    private void Awake()
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Target Casted : {other.name}");
        if (_doCasting)
        {
            if (1 << other.gameObject.layer == targetLayer)
            {
                if (other.gameObject.TryGetComponent(out Enemy enemy))
                {
                    int id = other.gameObject.GetInstanceID();
                    if (targets.TryGetValue(id, out GameObject target) == false)
                    {
                        targets.Add(id, target);
                        Debug.Log($"Target Casted : {id}");
                    }
                }
            }
        }
    }
}
