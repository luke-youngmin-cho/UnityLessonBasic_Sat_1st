using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PoolElement[] poolElements;
    [SerializeField] private float spawnTime = 3f;
    [SerializeField] private float spawnSlowDownRate = 0.7f;
    [SerializeField] private float spawnSlowDownTimeRate = 0.5f;

    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [SerializeField] private float zMin;
    [SerializeField] private float zMax;

    float[] timers;


    private void Awake()
    {
        timers = new float[poolElements.Length];
        for (int i = 0; i < poolElements.Length; i++)
        {
            timers[i] = spawnTime + Random.Range(0f, 2f);
        }
    }

    private void Start()
    {
        for (int i = 0; i < poolElements.Length; i++)
        {
            ObjectPool.instance.AddPoolElement(poolElements[i]);
        }

        ObjectPool.instance.CreatePoolElements();
    }

    private void Update()
    {
        if (ObjectPool.isReady == false) return;
        
        for (int i = 0; i < poolElements.Length; i++)
        {
            if (timers[i] < 0 &&
                ObjectPool.GetSpawnedObjectNumber(poolElements[i].tag) < poolElements[i].size)
            {
                ObjectPool.SpawnFromPool(poolElements[i].tag, GetRandomPosition(xMin, xMax, yMin, yMax, zMin, zMax));
                if (ObjectPool.GetSpawnedObjectNumber(poolElements[i].tag) >= poolElements[i].size * 0.7f)
                    timers[i] = spawnTime / spawnSlowDownTimeRate + Random.Range(0f, 2f);
                else
                    timers[i] = spawnTime + Random.Range(0f, 2f);
            }
            else
            {
                timers[i] -= Time.deltaTime;
            }
        }
    }

    private Vector3 GetRandomPosition(float xMin, float xMax, float yMin, float yMax, float zMin, float zMax)
    {
        return transform.TransformPoint(new Vector3(Random.Range(xMin, xMax),
                                                    Random.Range(yMin, yMax),
                                                    Random.Range(zMin, zMax)));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(xMax - xMin, yMax - yMin, zMax - zMin));
    }
}
