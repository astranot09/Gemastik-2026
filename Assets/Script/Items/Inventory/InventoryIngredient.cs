using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryIngredient : MonoBehaviour
{
    [Header("Visualisation")]
    [SerializeField] private TMP_Text ingredientText;
    [SerializeField] private Image ingredientImage;

    public void CreateVisual(IngredientSO ingredientData, int qty)
    {
        ingredientImage.sprite = ingredientData.ingredientSprite;
        ingredientText.text = $"{ingredientData.name} - {qty} item / {ingredientData.ingredientExpiredTime} day before expiry";
    }
}
