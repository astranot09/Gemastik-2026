using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private GameObject ingredientPrefab;

    private Dictionary<IngredientSO, List<Ingredient>> ingredientList = new();


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
        if (!ingredientList.TryGetValue(ingredientSO, out List<Ingredient> stacks))
        {
            stacks = new List<Ingredient>();
            ingredientList.Add(ingredientSO, stacks);
        }

        Ingredient existing = stacks.Find(x => x.expiry == ingredientSO.ingredientExpiredTime);

        if (existing != null)
        {
            existing.AddQuantity();
            existing.ui.UpdateVisual(existing);
        }
        else
        {
            Ingredient ingredient = new Ingredient(ingredientSO);

            stacks.Add(ingredient);
            CreateVisual(ingredient);
        }
    }

    public void DecreaseIngredient(IngredientSO ingredientSO)
    {
        if (ingredientList.TryGetValue(ingredientSO, out List<Ingredient> stacks))
        {
            Ingredient ingredient = stacks.OrderBy(i => i.expiry).First();

            ingredient.DecreaseQuantity();

            UpdateVisual(ingredient);

            if (ingredient.quantity <= 0)
            {
                ReducedToAtoms(ingredient);
            }
        }
    }

    public void DecreaseExpiry()
    {
        List<Ingredient> expired = new();

        foreach (List<Ingredient> stacks in ingredientList.Values)
        {
            foreach (Ingredient ingredient in stacks)
            {
                if (ingredient.DecreaseExpiry() <= 0)
                {
                    expired.Add(ingredient);
                }
                else
                {
                    ingredient.ui.UpdateVisual(ingredient);
                }
            }
        }

        foreach (Ingredient ingredient in expired)
        {
            ThrowIngredient(ingredient);
        }
    }

    private void ReducedToAtoms(Ingredient ingredient)
    {
        Destroy(ingredient.ui.gameObject);
        ingredientList[ingredient.data].Remove(ingredient);
        if (ingredientList[ingredient.data].Count == 0)
        {
            ingredientList.Remove(ingredient.data);
        }
    }

    private void ThrowIngredient(Ingredient ingredient)
    {
        WasteManager.instance.WasteIngredient(ingredient.quantity, ingredient.data);
        ReducedToAtoms(ingredient);
    }

    private void CreateVisual(Ingredient ingredient)
    {
        GameObject obj = Instantiate(ingredientPrefab, contentPanel.transform.position, Quaternion.identity, contentPanel.transform);
        InventoryIngredient ui = obj.GetComponent<InventoryIngredient>();
        ingredient.ui = ui;
        ui.CreateVisual(ingredient);
    }

    private void UpdateVisual(Ingredient ingredient)
    {
        ingredient.ui.UpdateVisual(ingredient);
    }
}
