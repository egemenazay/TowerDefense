using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool objectPool;
    public Transform spawnLocation;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnOEnemy),0f, 5f);
    }

    private void SpawnOEnemy()
    {
        GameObject obj = objectPool.GetEnemy();
        if (obj != null)
        {
            obj.transform.position = spawnLocation.position;
        }
        EnemyManager.EnemyManagerInstance.RegisterEnemy(obj.transform);
    }

}
