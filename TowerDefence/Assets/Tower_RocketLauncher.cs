using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_RocketLauncher : Tower
{
    public GameObject rocketPrefab;
    public int damage;
    public float reloadTime;
    public float reloadTimer;
    [SerializeField] private Transform[] firePoints;

    protected override void Update()
    {
        base.Update();

        // ¿Á¿Â¿¸
        if (reloadTimer < 0)
        {
            if (target != null)
            {
                Attack();
                reloadTimer = reloadTime;
            }
        }
        else
        {
            reloadTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        foreach (var firePoint in firePoints)
        {
            GameObject rocket = Instantiate(rocketPrefab, firePoint.position, Quaternion.identity);
            Vector3 dir = (target.transform.position - rocket.transform.position).normalized;
            rocket.GetComponent<Rocket>().SetUp(dir, damage);
        }
    }
}
