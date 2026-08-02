using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    [Header("Read Only")]
    [SerializeField] private IngredientSO ingredientData = null;
    [SerializeField] private TMP_Text ingredientText;

    private string name;
    private Sprite sprite;
    private int expiry;
    private int qty;
    private string desc;
    public void Initialize(IngredientSO ingredientSO)
    {
        ingredientData = ingredientSO;
        name = ingredientData.ingredientName;
        sprite = ingredientData.ingredientSprite;
        expiry = ingredientData.ingredientExpiredTime;
        qty = ingredientData.ingredientQuantity;
        desc = name + " - " + qty + " item / " + expiry + " day before expiry";
        Debug.Log(desc);
    }
}
