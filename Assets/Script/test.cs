using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private IngredientSO ingredient;
    public void testExpiry()
    {
        InventoryManager.Instance.DecreaseExpiry();
    }

    public void testQuantityBawang()
    {
        InventoryManager.Instance.DecreaseIngredient(ingredient);
    }
}
