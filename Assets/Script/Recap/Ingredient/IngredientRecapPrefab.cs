using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientRecapPrefab : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private RecapIngredientClass recapIngredientData;

    [Header("UI")]
    [SerializeField] private Image ingredientIcon;
    [SerializeField] private TMP_Text ingredientName;
    [SerializeField] private TMP_Text ingredientCount;

    public void SetUpRecapMenuPrefab(RecapIngredientClass data)
    {
        recapIngredientData = data;
        ingredientIcon.sprite = recapIngredientData.ingredient.ingredientSprite;
        ingredientName.text = recapIngredientData.ingredient.ingredientName;
        ingredientCount.text = $"{recapIngredientData.quantity} / {recapIngredientData.maxQuantity}"; //tinggal ganti pas awal mulai
    }
}
