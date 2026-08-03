using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class RecapIngredientClass
{
    public IngredientSO ingredient;
    public int quantity = 0;
    public int maxQuantity = 0;
    // Constructor to initialize the item
    public RecapIngredientClass(IngredientSO ingredientSO, int initialQuantity = 0, int max = 10)
    {
        ingredient = ingredientSO;
        quantity = initialQuantity;
        maxQuantity = max;
    }
}

[System.Serializable]
public class RecapMenuClass
{
    public MenuSO menu;
    public int quantity = 0;

    // Constructor to initialize the item
    public RecapMenuClass(MenuSO menuSO, int initialQuantity = 1)
    {
        menu = menuSO;
        quantity = initialQuantity;
    }
}

public class RecapManager : MonoBehaviour
{
    public static RecapManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private GameObject recapPanel;

    [Header("Recap Food")]
    [SerializeField] private List<RecapMenuClass> recapList = new List<RecapMenuClass>();
    [SerializeField] private GameObject menuRecapPrefab;
    [SerializeField] private Transform menuRecapTransform;


    [Header("Recap Ingredient")]
    [SerializeField] private List<RecapIngredientClass> ingredientList = new List<RecapIngredientClass>();
    [SerializeField] private GameObject ingredientRecapPrefab;
    [SerializeField] private Transform ingredientRecapTransform;


    [Header("Reference")]
    [SerializeField] private GameManager gameManager;


    private void OnEnable()
    {
        gameManager.OnDayEnd += SetUpRecapUI;
    }
    private void OnDisable()
    {
        gameManager.OnDayEnd -= SetUpRecapUI;
    }

    public void AddRecapMenu(MenuSO menuSO)
    {
        if (menuSO == null) return;

        // Find existing recap item matching the ScriptableObject
        RecapMenuClass existingRecap = recapList.Find(recap => recap.menu == menuSO);

        if (existingRecap != null)
        {
            // Item exists -> Increment quantity
            existingRecap.quantity++;
        }
        else
            // Item does not exist -> Create new entry
            recapList.Add(new RecapMenuClass(menuSO));
    }



    public void ResetRecapMenu()
    {
        recapList.Clear();
        for (int i = menuRecapTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(menuRecapTransform.GetChild(i).gameObject);
        }
    }

    public void SetUpRecapUI()
    {
        Debug.Log("PPPPPPPPPPPPP");
        recapPanel.SetActive(true);

        foreach (RecapMenuClass recap in recapList)
        {
            GameObject x = Instantiate(menuRecapPrefab, menuRecapTransform);
            x.GetComponent<RecapMenuPrefab>().SetUpRecapMenuPrefab(recap);
        }
    }
    public void CloseRecapUI()
    {
        ResetRecapMenu();
        recapPanel.SetActive(false);
        GameManager.instance.NextDay();
    }

    // ================= INGREDIENT ==================

    public void AddRecapIngredient(IngredientSO ingredientSO)
    {
        if (ingredientSO == null) return;

        // Find existing recap item matching the ScriptableObject
        RecapIngredientClass existingRecap = ingredientList.Find(recap => recap.ingredient == ingredientSO);

        if (existingRecap != null)
        {
            // Item exists -> Increment quantity
            existingRecap.quantity++;
        }
        else
            // Item does not exist -> Create new entry
            ingredientList.Add(new RecapIngredientClass(ingredientSO));
    }

    public void InitRecapIngredient(List<IngredientSO> listIngredientInventory)
    {
        if (listIngredientInventory == null) return;

        foreach(IngredientSO ingredientInventory in listIngredientInventory)
        {
            ingredientList.Add(new RecapIngredientClass(ingredientInventory, 0, 10)); // 10 diambil dari inventory, ambil pas start day
        }


    }
}
