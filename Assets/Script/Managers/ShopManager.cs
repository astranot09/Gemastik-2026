using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<IngredientSO> ingredientList;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject shopItemPrefab;

    private void Start()
    {
        CreateIngredientListings();
    }

    private void CreateIngredientListings()
    {
        GameObject newIngredient = Instantiate(shopItemPrefab, shopPanel.transform.position, Quaternion.identity, shopPanel.transform);
        Ingredient ingredient = GetComponent<Ingredient>();
        for (int i = 0; i < ingredientList.Count; i++)
        {
            ingredient.Initialize(ingredientList[i]);
        }
    }
}
