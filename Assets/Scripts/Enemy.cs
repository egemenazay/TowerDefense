using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    [SerializeField] private Transform targetTower;

    void Update()
    {
        //FindClosestTower();
        
        if (targetTower != null)
        {
            // Move towards the target tower
            transform.position = Vector3.MoveTowards(transform.position, targetTower.position, speed * Time.deltaTime);

            // Optional: Rotate to face the target
            Vector3 direction = (targetTower.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    /*void FindClosestTower()
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

        targetTower = closestTower;
    }*/
}
