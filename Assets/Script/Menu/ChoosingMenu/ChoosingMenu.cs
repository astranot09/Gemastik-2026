using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    private List<MenuSO> newMenu= new List<MenuSO>();
    public List<MenuSO> MenuSelected => menuSelected;

    [Header("Prefab")]
    [SerializeField] private GameObject menuPrefab;
    [SerializeField] private Transform menuTransform;

    [Header("Setting")]
    [SerializeField] private int maxMenuCanBeSelected = 3;
    public int MaxMenuCanBeSelected => maxMenuCanBeSelected;

    private int currentSelected = 0;
    public int CurrentSelected => currentSelected;

    private bool init = false;
    private bool refreshUI = true;


    [Header("Description")]
    [SerializeField] private Image menuIcon;
    [SerializeField] private TMP_Text menuName;
    [SerializeField] private TMP_Text menuDescription;
    [SerializeField] private GameObject ingredientPrefab;
    [SerializeField] private Transform ingredientPrefabSpawner;


    private void Start()
    {
        SetUpMenuPrefab();
    }
    public void SetUpMenuPrefab()
    {
        ResetDescriptionMenu();
        if (!refreshUI) return;

        refreshUI = false;

        if (!init)
        {
            init = true;
            foreach (var menu in allRestaurantMenu)
            {
                GameObject x = Instantiate(menuPrefab, menuTransform);
                x.GetComponent<ChoosingMenuPrefab>().InitMenu(menu);
            }
        }
        else
        {
            foreach (var menu in newMenu)
            {
                GameObject x = Instantiate(menuPrefab, menuTransform);
                x.GetComponent<ChoosingMenuPrefab>().InitMenu(menu);
            }
            newMenu.Clear();
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

    public void AddNewMenu(MenuSO menu)
    {
        allRestaurantMenu.Add(menu);
        newMenu.Add(menu);
        refreshUI = true;
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


    //=========================================================  DESCRIPTION ===============================================================
    public void ResetDescriptionMenu()
    {
        menuIcon.enabled = false;
        menuName.text = string.Empty;
        menuDescription.text = string.Empty;
        for (int i = ingredientPrefabSpawner.childCount - 1; i >= 0; i--)
        {
            Destroy(ingredientPrefabSpawner.GetChild(i).gameObject);
        }
    }

    public void OpenDescriptionMenu(MenuSO menu)
    {
        ResetDescriptionMenu();
        menuIcon.enabled = true;
        menuIcon.sprite = menu.menuSprite;
        menuName.text = menu.menuName;
        menuDescription.text = menu.menuDescription;
        foreach(IngredientSO x in menu.listIngredient)
        {
            GameObject n = Instantiate(ingredientPrefab, ingredientPrefabSpawner);
            n.GetComponent<IngredientDescriptionPrefabScript>().SetUpUI(x);
        }
    }

}
