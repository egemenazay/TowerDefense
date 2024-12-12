using System;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float speed = 5f;
    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 direction = (Tower.currentTargetEnemy.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
