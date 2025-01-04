using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 5f;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnOEnemy),0f, spawnRate);
    }

    private void SpawnOEnemy()
    {
        GameObject obj = enemyPrefab;
        Instantiate(obj, gameObject.transform.position, obj.transform.rotation);
    }

}
