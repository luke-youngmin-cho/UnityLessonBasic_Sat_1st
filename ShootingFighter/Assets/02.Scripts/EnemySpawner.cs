using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 rangeCenter;
    public Vector3 rangeSize;

    public float spawnTimeGap = 0.3f;
    private float spawnTimer;

    private void Update()
    {
        Vector3 spawnPos = new Vector3(rangeCenter.x + Random.Range(-rangeSize.x / 2, rangeSize.x / 2),
                                       rangeCenter.y + Random.Range(-rangeSize.y / 2, rangeSize.y / 2),
                                       rangeCenter.z + Random.Range(-rangeSize.z / 2, rangeSize.z / 2));
                                  
        if (spawnTimer < 0)
        {
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            spawnTimer = spawnTimeGap;
        }   
        else
            spawnTimer -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(rangeCenter, rangeSize);
    }
    
}
