using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopIngredient : MonoBehaviour
{
    [Header("Visualisation")]
    [SerializeField] private TMP_Text ingredientText;
    [SerializeField] private Image ingredientImage;

    private IngredientSO ingredientData;
    public void CreateVisual(IngredientSO ingredientSO)
    {
        ingredientData = ingredientSO;
        ingredientText.text = $"{ingredientSO.ingredientName} - {ingredientSO.ingredientPrice}K";
        ingredientImage.sprite = ingredientSO.ingredientSprite;
    }

    public void AddToInventory()
    {
        InventoryManager.Instance.AddIngredient(ingredientData);
    }
}
