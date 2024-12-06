using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingDistance = 1.5f; // Distance at which the unit stops
    private Transform currentTargetTower;

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

        foreach (Transform tower in TowerManager.Instance.towers)
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
}
