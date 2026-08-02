using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private GameObject ingredientPrefab;

    private Dictionary<IngredientSO, int> ingredientList = new();

    public void AddIngredient(IngredientSO ingredient)
    {
        if (ingredientList.ContainsKey(ingredient))
        {
            ingredientList[ingredient]++;
            CreateVisual(ingredient, ingredientList[ingredient]);
        }
        else
        {
            ingredientList.Add(ingredient, 1);
            CreateVisual(ingredient, ingredientList[ingredient]);
        }

        foreach (var pair in ingredientList)
        {
            Debug.Log($"{pair.Key.ingredientName}: {pair.Value}");
        }
    }

    private void CreateVisual(IngredientSO ingredientData, int qty)
    {
        GameObject newIngredient = Instantiate(ingredientPrefab, contentPanel.transform.position, Quaternion.identity, contentPanel.transform);
        InventoryIngredient ingredient = newIngredient.GetComponent<InventoryIngredient>();
        ingredient.CreateVisual(ingredientData, qty);
    }

    private void UpdateVisual(IngredientSO ingredientData, int qty)
    {

    }
}
