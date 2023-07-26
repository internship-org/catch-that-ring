using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Menu[] menus;

    public void OpenMenu(Menu openMenu)
    {
        // Close all menus
        foreach (var menu in menus)
        {
            if (menu == openMenu)
                menu.Open();
            else
                menu.Close();
        }
    }

    public void CloseAllMenus()
    {
        foreach (var menu in menus)
        {
            menu.Close();
        }
    }
}
