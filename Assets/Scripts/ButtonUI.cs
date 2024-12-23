using DefaultNamespace;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public void ButtonMagicTower()
    {
        TowerSpawner.TowerSpawnerInstance.SpawnTower(PlaceHolder.selectedPlace.transform.position);
        ButtonClose();
    }
    public void ButtonClose()
    {
        
        MenuManager.MenuManagerInstance.HideUnitMenu();
    }
}
