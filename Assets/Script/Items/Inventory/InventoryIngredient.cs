using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryIngredient : MonoBehaviour
{
    [Header("Visualisation")]
    [SerializeField] private TMP_Text ingredientText;
    [SerializeField] private Image ingredientImage;

    public void CreateVisual(Ingredient ingredientData)
    {
        ingredientImage.sprite = ingredientData.data.ingredientSprite;
        ingredientText.text = $"{ingredientData.data.ingredientName} - {ingredientData.quantity} item / {ingredientData.expiry} day before expiry";
    }

    public void UpdateVisual(Ingredient ingredient)
    {
        ingredientText.text = $"{ingredient.data.ingredientName} - {ingredient.quantity} item / {ingredient.expiry} day before expiry";
    }
}
