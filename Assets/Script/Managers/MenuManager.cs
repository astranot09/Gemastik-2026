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

    [Header("Reference")]
    [SerializeField] private GameManager gameManager;


    private void OnEnable()
    {
        gameManager.OnDayStart += CheckDay;
    }
    private void OnDisable()
    {
        gameManager.OnDayStart -= CheckDay;
    }

    private void Start()
    {
        CheckDay();
    }
    public void CheckDay()
    {
        int day = GameManager.instance.Day;
        Debug.Log("XD");
        if(day == 4)
        {
            Debug.Log("22");
            foreach (MenuSO menu in day4NewMenu)
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
