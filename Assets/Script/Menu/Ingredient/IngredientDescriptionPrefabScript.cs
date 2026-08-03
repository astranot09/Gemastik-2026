using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IngredientDescriptionPrefabScript : MonoBehaviour
{
    [SerializeField] private Image iconIngredient;
    [SerializeField] private TMP_Text nameIngredient;
    public void SetUpUI(IngredientSO ingredientSO)
    {
        iconIngredient.sprite = ingredientSO.ingredientSprite;
        nameIngredient.text = ingredientSO.ingredientName;
    }
}
