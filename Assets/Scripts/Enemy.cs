using System;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float health = 2f;
    public float stoppingDistance = 25f; // Distance to stop
    private Transform currentTargetTower;
    private NavMeshAgent agent;

    private void Awake()
    {
        // Get or add the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
            agent = gameObject.AddComponent<NavMeshAgent>();

        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;
        agent.autoBraking = true; // Smoothly stop near the target
    }

    private void Update()
    {
        FindClosestTower();

        if (currentTargetTower != null)
        {
            agent.SetDestination(currentTargetTower.position);

            // Check if the agent is near the stopping distance
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                // Look at the tower when stopped
                LookAtTarget();
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

    private void LookAtTarget()
    {
        Vector3 direction = (currentTargetTower.position - transform.position).normalized;

        // Ignore changes in the Y-axis to prevent tilting
        direction.y = 0;

        if (direction.magnitude > 0)
        {
            // Smoothly rotate to face the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon"))
        {
            health--;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                KillEnemy();
            }
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
        EnemyManager.EnemyManagerInstance.UnregisterEnemy(transform);
    }

    private void OnDisable()
    {
        EnemyManager.EnemyManagerInstance.UnregisterEnemy(transform);
    }

    private void OnEnable()
    {
        EnemyManager.EnemyManagerInstance.RegisterEnemy(transform);
    }
}
