using System.Collections.Generic;
using UnityEngine;

public class FoodToNPC : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Transform> pathOrder = new List<Transform>();

    public void SetUpFood(Sprite foodSprite, List<Transform> path)
    {
        spriteRenderer.sprite = foodSprite;
        pathOrder.Clear();
        pathOrder = path;
    }
}
