using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Ingredient
{
    public IngredientSO data;
    public int quantity;
    public int expiry;

    public InventoryIngredient ui;

    public Ingredient(IngredientSO ingredientSO)
    {
        data = ingredientSO;
        quantity = 1;
        expiry = ingredientSO.ingredientExpiredTime;

    }

    public void AddQuantity(int amount = 1)
    {
        quantity += amount;
    }

    public int DecreaseQuantity(int amount = 1)
    {
        quantity -= amount;
        return quantity;
    }

    public int DecreaseExpiry()
    {
        expiry--;
        return expiry;
    }
}
