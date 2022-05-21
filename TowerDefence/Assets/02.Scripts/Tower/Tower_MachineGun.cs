using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_MachineGun : Tower
{
    public float damage;
    public float reloadTime;
    private float reloadTimer;

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
        target.GetComponent<Enemy>().hp -= damage;
    }
}
