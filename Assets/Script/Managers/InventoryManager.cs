using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private GameObject ingredientPrefab;
    private List<IngredientSO> ingredientList;

    public void AddIngredient(IngredientSO ingredient)
    {

    }
}
