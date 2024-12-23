using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingDistance = 1.5f; // Distance at which the unit stops
    private Transform currentTargetTower;
    [SerializeField] public ObjectPool objectPool;

    [Obsolete("Obsolete")]
    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        FindClosestTower();

        if (currentTargetTower != null)
        {
            float distance = Vector3.Distance(transform.position, currentTargetTower.position);

            if (distance > stoppingDistance)
            {
                // Move towards the tower
                MoveTowardsTower();
            }
        }
    }
    void FindClosestTower()
    {
        float closestDistance = Mathf.Infinity;
        Transform closestTower = null;

        foreach (Transform tower in TowerManager.TowerManagerInstance.towers)
        {
            float distance = Vector3.Distance(transform.position, tower.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTower = tower;
            }
        }
        currentTargetTower = closestTower;
    }

    void MoveTowardsTower()
    {
        Vector3 direction = (currentTargetTower.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Rotate towards the target tower
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon"))
        {
            KillEnemy();
            Destroy(other.gameObject);
        }
    }

    private void KillEnemy()
    {
        Debug.Log("ENEMY HIT");
        objectPool.ReturnEnemy(gameObject);
        EnemyManager.EnemyManagerInstance.UnregisterEnemy(gameObject.transform);
    }
}
