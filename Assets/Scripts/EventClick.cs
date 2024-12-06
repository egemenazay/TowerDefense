using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    private TowerSpawn _towerSpawn;

    private void Awake()
    {
        _towerSpawn = GetComponent<TowerSpawn>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _towerSpawn.TestDown();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _towerSpawn.TestClick();
    }
}
