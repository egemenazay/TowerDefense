using UnityEngine;
using System.Collections.Generic;
public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;
    public List<Transform> towers = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
