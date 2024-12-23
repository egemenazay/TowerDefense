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
    public void HideUnitMenu()
    {
        unitMenu.SetActive(false);
        isUnitMenuActive = false;
    }
}
