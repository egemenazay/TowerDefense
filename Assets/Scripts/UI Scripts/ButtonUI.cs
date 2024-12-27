using DefaultNamespace;
using System.Collections;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public void ButtonMagicTower()
    {
        Vector3 spawnPos = PlaceHolder.selectedPlace.transform.position;
        spawnPos.y += 1.8f;
        TowerSpawner.TowerSpawnerInstance.SpawnTower(spawnPos);
        Destroy(PlaceHolder.selectedPlace);
        ButtonClose();
    }
    public void ButtonClose()
    {
        TweenUnitMenu.TweenUnitMenuInstance.HideMenuAnim();
        MenuManager.MenuManagerInstance.StarCour();
    }
}
