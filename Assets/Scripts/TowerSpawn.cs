using System;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] public GameObject tower;
    public void TestDown()
    {
        Debug.Log("Mouse Down");
    }
    public void TestClick()
    {
        Debug.Log("Mouse Click");
    }

    private void OnMouseDown()
    {
        Debug.Log("MouseButtonDOwn");
    }
}
