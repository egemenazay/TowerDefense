using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    public static GameObject currentTargetEnemy;
    public Transform firePoint;
    public static float towerRange = 10f;
    public float fireRate = 1f; // Time between shots in seconds
    private float fireCooldown = 0f;
    

    private void Update()
    {
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
        FindCLosestEnemy();
        if (currentTargetEnemy != null && currentTargetEnemy.transform != null)
        {
            float distance = Vector3.Distance(transform.position, currentTargetEnemy.transform.position);

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
        if (closestEnemy != null) currentTargetEnemy = closestEnemy.gameObject;
    }
    private void FireCannon()
    {
        Instantiate(cannon, firePoint.position, firePoint.rotation);
    }

    private void OnDisable()
    {
        TowerManager.TowerManagerInstance.UnregisterTower(transform);
    }
    private void OnEnable()
    {
        TowerManager.TowerManagerInstance.RegisterTower(transform);
    }
}
