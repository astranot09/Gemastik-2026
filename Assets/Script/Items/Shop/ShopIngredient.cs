using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopIngredient : MonoBehaviour
{
    [Header("Visualisation")]
    [SerializeField] private TMP_Text ingredientText;
    [SerializeField] private Image ingredientImage;
    public void CreateVisual(IngredientSO ingredientSO)
    {
        ingredientText.text = $"{ingredientSO.ingredientName} - {ingredientSO.ingredientPrice}K";
        ingredientImage.sprite = ingredientSO.ingredientSprite;
    }
}
