using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance;
    
    public void ActiveBuff(Enemy enemy, Buff buff)
    {
        StartCoroutine(E_ActiveBuff(enemy, buff));
    }

    private IEnumerator E_ActiveBuff(Enemy enemy, Buff buff)
    {
        buff.OnActive(enemy);
        bool doBuff = true;
        float timeMark = Time.time;

        while (doBuff &&
               Time.time - timeMark < buff.duration)
        {
            doBuff = buff.OnDuration(enemy);
            yield return null;
        }

        buff.OnDeactive(enemy);
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }
}
