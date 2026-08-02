using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("List Of IngredientSO")]
    [SerializeField] private List<IngredientSO> ingredientList;

    [Header("Shop")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject shopItemPrefab;

    private void Start()
    {
        CreateIngredientListings();
    }

    private void CreateIngredientListings()
    {
        foreach(IngredientSO ingredient in ingredientList)
        {
            GameObject newIngredient = Instantiate(shopItemPrefab, shopPanel.transform.position, Quaternion.identity, shopPanel.transform);
            Debug.Log(newIngredient);
            CreateShopItem(newIngredient, ingredient);
        }
    }

    private void CreateShopItem(GameObject ingredientObject, IngredientSO ingredientData)
    {
        ShopIngredient ingredient = ingredientObject.GetComponent<ShopIngredient>();
        ingredient.CreateVisual(ingredientData);
    }
}
