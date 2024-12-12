using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager EnemyManagerInstance;
    public List<Transform> enemies = new List<Transform>();

    private void Awake()
    {
        if (EnemyManagerInstance == null)
            EnemyManagerInstance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterEnemy(Transform enemy)
    {
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(Transform enemy)
    {
        enemies.Remove(enemy);
    }
}
