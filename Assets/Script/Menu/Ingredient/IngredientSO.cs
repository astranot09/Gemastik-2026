using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "Scriptable Objects/IngredientSO")]
public class IngredientSO : ScriptableObject
{
    public string ingredientName;
    public Sprite ingredientSprite;
    public int ingredientPrice;
    public int ingredientExpiredTime;
}
