using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private List<MenuSO> day4NewMenu;
    [SerializeField] private List<MenuSO> day8NewMenu;
    [SerializeField] private List<MenuSO> day17NewMenu;

    private void Start()
    {
        CheckDay();
    }
    public void CheckDay()
    {
        int day = GameManager.instance.Day;

        if(day == 4)
        {
            foreach(MenuSO menu in day4NewMenu)
            {
                ChoosingMenu.instance.AddNewMenu(menu);
            }
        }
        else if (day == 8)
        {
            foreach (MenuSO menu in day8NewMenu)
            {
                ChoosingMenu.instance.AddNewMenu(menu);
            }
        }
        else if (day == 17)
        {
            foreach (MenuSO menu in day17NewMenu)
            {
                ChoosingMenu.instance.AddNewMenu(menu);
            }
        }
    }
}
