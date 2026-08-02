using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    [Header("Read Only")]
    [SerializeField] protected IngredientSO ingredientData = null;

    protected InventoryManager inventoryManager;
    protected string name;
    protected Sprite sprite;
    protected int expiry;
    protected int price;
    public virtual void Initialize(IngredientSO ingredientSO)
    {
        ingredientData = ingredientSO;
        name = ingredientData.ingredientName;
        sprite = ingredientData.ingredientSprite;
        expiry = ingredientData.ingredientExpiredTime;
        price = ingredientData.ingredientPrice;

        inventoryManager = GameObject.FindFirstObjectByType<InventoryManager>();
    }

    public void AddToInventory()
    {
        inventoryManager.AddIngredient(ingredientData);
        Debug.Log("Added to Inventory");
    }
}
