using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Slow : Buff
{
    public float slowPercent;
    private  EnemyMovement enemyMovement;
    private float enemySpeedOrigin;

    public override void OnActive(Enemy target)
    {
        base.OnActive(target);
        enemyMovement = target.GetComponent<EnemyMovement>();
        enemySpeedOrigin = enemyMovement.moveSpeed;

        float tmpSpeed = enemySpeedOrigin * (1f - slowPercent / 100.0f);
        if (enemyMovement.moveSpeed > tmpSpeed)
            enemyMovement.moveSpeed = tmpSpeed;
    }

    public override void OnDeactive(Enemy target)
    {
        base.OnDeactive(target);

        if (target != null)
            enemyMovement.moveSpeed = enemySpeedOrigin;
    }

    public override bool OnDuration(Enemy target)
    {
        return target == null ? false : true;
    }
}
