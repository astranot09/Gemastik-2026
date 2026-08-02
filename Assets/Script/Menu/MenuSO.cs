using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuSO", menuName = "Scriptable Objects/MenuSO")]
public class MenuSO : ScriptableObject
{
    public string menuName;
    public Sprite menuSprite;
    public List<IngredientSO> listIngredient;
    public int menuPrice;
}
