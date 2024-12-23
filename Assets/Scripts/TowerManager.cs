using System;
using UnityEngine;
using System.Collections.Generic;
public class TowerManager : MonoBehaviour
{
    public static TowerManager TowerManagerInstance;
    public List<Transform> towers = new List<Transform>();
    [SerializeField] public GameObject motherbase;

    private void Awake()
    {
        if (TowerManagerInstance == null)
            TowerManagerInstance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        RegisterTower(motherbase.transform);
    }

    public void RegisterTower(Transform tower)
    {
        towers.Add(tower);
    }

    public void UnregisterTower(Transform tower)
    {
        towers.Remove(tower);
    }
}
