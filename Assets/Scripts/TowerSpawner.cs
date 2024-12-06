using System;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    
    [SerializeField] public GameObject tower;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is this object
                if (hit.collider.gameObject == gameObject)
                {
                    OnClick();
                }
            }
        }
    }

    void OnClick()
    {
        SpawnTower(gameObject.transform.position);
        gameObject.SetActive(false);
    }
    
    public void SpawnTower(Vector3 pos)
    {
        Instantiate(tower, pos, Quaternion.identity);
    }
}