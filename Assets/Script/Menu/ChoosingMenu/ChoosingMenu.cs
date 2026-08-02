using System.Collections.Generic;
using UnityEngine;


public class ChoosingMenu : MonoBehaviour
{

    public static ChoosingMenu instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    [Header("Data")]
    [SerializeField] private List<MenuSO> allRestaurantMenu = new List<MenuSO>();
    [SerializeField] private List<MenuSO> menuSelected = new List<MenuSO>();
    public List<MenuSO> MenuSelected => menuSelected;

    [Header("Prefab")]
    [SerializeField] private GameObject menuPrefab;
    [SerializeField] private Transform menuTransform;

    [Header("Setting")]
    [SerializeField] private int maxMenuCanBeSelected = 3;
    public int MaxMenuCanBeSelected => maxMenuCanBeSelected;

    private int currentSelected = 0;
    public int CurrentSelected => currentSelected;


    private void Start()
    {
        SetUpMenuPrefab();
    }
    public void SetUpMenuPrefab()
    {
        foreach(var menu in allRestaurantMenu)
        {
            GameObject x = Instantiate(menuPrefab, menuTransform);
            x.GetComponent<ChoosingMenuPrefab>().InitMenu(menu);
        }
    }


    public void AddSelectedMenu(MenuSO menu)
    {
        currentSelected++;
        menuSelected.Add(menu);
    }
    public void RemoveSelectedMenu(MenuSO menu)
    {
        currentSelected--;
        menuSelected.Remove(menu);
    }


    //public void SubmitSelected()
    //{
    //    menuSelected.Clear();
    //    foreach(SelectMenu menu in allRestaurantMenu)
    //    {
    //        if (menu.isSelected)
    //        {
    //            menuSelected.Add(menu.menu);
    //        }
    //    }
    //}

}
