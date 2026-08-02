using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private GameObject ingredientPrefab;

    private Dictionary<IngredientSO, Ingredient> ingredientList = new();
    private Dictionary<IngredientSO, InventoryIngredient> ingredientUIList = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddIngredient(IngredientSO ingredientSO)
    {
        if (ingredientList.TryGetValue(ingredientSO, out Ingredient ingredient))
        {
            ingredient.AddQuantity();
            UpdateVisual(ingredient);
        }
        else
        {
            ingredient = new Ingredient(ingredientSO);

            ingredientList.Add(ingredientSO, ingredient);
            CreateVisual(ingredient);
        }

        foreach (var pair in ingredientList)
        {
            Debug.Log($"{pair.Key.ingredientName}: {pair.Value}");
        }
    }

    public void DecreaseIngredient(IngredientSO ingredientSO)
    {
        if (ingredientList.TryGetValue(ingredientSO, out Ingredient ingredient))
        {
            ingredient.DecreaseQuantity();
            UpdateVisual(ingredient);
        }
        else
        {
            ingredient = new Ingredient(ingredientSO);

            ingredientList.Add(ingredientSO, ingredient);
            CreateVisual(ingredient);
        }

        foreach (var pair in ingredientList)
        {
            Debug.Log($"{pair.Key.ingredientName}: {pair.Value}");
        }
    }



    private void CreateVisual(Ingredient ingredientData)
    {
        GameObject newIngredient = Instantiate(ingredientPrefab, contentPanel.transform.position, Quaternion.identity, contentPanel.transform);
        InventoryIngredient ingredient = newIngredient.GetComponent<InventoryIngredient>();
        ingredient.CreateVisual(ingredientData);
        ingredientUIList.Add(ingredientData.data, ingredient);
    }

    private void UpdateVisual(Ingredient ingredientData)
    {
        ingredientUIList[ingredientData.data].UpdateVisual(ingredientData);
    }
}
