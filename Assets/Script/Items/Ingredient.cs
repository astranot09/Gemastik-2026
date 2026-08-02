using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Ingredient
{
    public IngredientSO data;
    public int quantity;
    public int expiry;

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

    public void DecreaseQuantity(int amount = 1)
    {
        quantity -= amount;
    }

    public void DecreaseExpiry()
    {
        expiry--;
        if (expiry <= 0)
        {
            //ingredient gone
        }
    }
}
