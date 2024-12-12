using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    public static Transform currentTargetEnemy;
    public Transform firePoint;
    public float towerRange = 10f;
    public float fireRate = 1f; // Time between shots in seconds
    private float fireCooldown = 0f;
    

    private void Update()
    {
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
        FindCLosestEnemy();
        if (currentTargetEnemy == null)
        {
            FindCLosestEnemy();
        }
        if (currentTargetEnemy != null)
        {
            float distance = Vector3.Distance(transform.position, currentTargetEnemy.position);

            if (distance < towerRange)
            {
                if (fireCooldown <= 0f)
                {
                    FireCannon();
                    fireCooldown = fireRate;
                }
            }
        }
    }

    void FindCLosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Transform enemy in EnemyManager.EnemyManagerInstance.enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        currentTargetEnemy = closestEnemy;
    }
    private void FireCannon()
    {
        Instantiate(cannon, firePoint.position, firePoint.rotation);
    }
    private void OnEnable()
    {
        TowerManager.TowerManagerInstance.RegisterTower(transform);
    }

    private void OnDisable()
    {
        TowerManager.TowerManagerInstance.UnregisterTower(transform);
    }
}
