using System;
using System.Collections;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject unitMenu;
    public static MenuManager MenuManagerInstance;
    public static bool isUnitMenuActive = false;

    private void Awake()
    {
        if (MenuManagerInstance == null)
            MenuManagerInstance = this;
        else
            Destroy(gameObject);
    }

    public void ShowUnitMenu()
    {
        unitMenu.SetActive(true);
        isUnitMenuActive = true;
    }

    private IEnumerator HideUnitMenu(float delay)
    {
        yield return new WaitForSeconds(delay);unitMenu.SetActive(false);
        // Tüm PlaceHolder'ları sıfırla
    }
    
    public void StarCour()
    {
        StartCoroutine(HideUnitMenu(0.3f));
        foreach (PlaceHolder placeHolder in PlaceHolder.allPlaceHolders)
        {
            placeHolder.ChangeOriginal();
        }
        isUnitMenuActive = false;
    }
}
