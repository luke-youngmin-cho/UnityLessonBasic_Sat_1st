using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float duration;
    public bool doBuff = true;
    public virtual void OnActive(Enemy target)
    {

    }

    public virtual void OnDeactive(Enemy target)
    {

    }

    public virtual bool OnDuration(Enemy target)
    {
        return doBuff;
    }

    public void TurnOff()
    {
        doBuff = false;
    }
}
