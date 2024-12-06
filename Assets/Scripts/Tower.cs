using System;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private void OnEnable()
    {
        TowerManager.Instance.RegisterTower(transform);
    }

    private void OnDisable()
    {
        TowerManager.Instance.UnregisterTower(transform);
    }
}
