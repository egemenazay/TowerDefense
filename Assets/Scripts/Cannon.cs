using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Cannon : MonoBehaviour
{
    public float speed = 5f;
    public float distance;
    public Vector3 enemyLastDirection;
    private GameObject enemy;

    private void Start()
    {
        enemy = Tower.currentTargetEnemy;
    }

    private void Update()
    {
        MoveEnemy();
        Debug.Log(distance.ToString());
    }

    private void MoveEnemy()
    {
        if (enemy.activeSelf)
        {
            distance = Vector3.Distance(gameObject.transform.position, enemy.transform.position); // cannon topu ile düşman arasındaki mesafe
            enemyLastDirection = enemy.transform.position - transform.position;
            enemyLastDirection.Normalize();
            if (distance < Tower.towerRange)
            {
                Vector3 direction = (enemy.transform.position - transform.position).normalized;
                transform.position += direction * (speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position += enemyLastDirection * (speed * Time.deltaTime);
        }

        
    }
}