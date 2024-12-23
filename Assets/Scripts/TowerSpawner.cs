using System;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public static TowerSpawner TowerSpawnerInstance;
    [SerializeField] public GameObject tower;
    private void Awake()
    {
        if (TowerSpawnerInstance == null)
            TowerSpawnerInstance = this;
        else
            Destroy(gameObject);
    }
    public void SpawnTower(Vector3 pos)
    {
        Instantiate(tower, pos, Quaternion.identity);
    }
}