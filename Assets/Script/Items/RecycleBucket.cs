using UnityEngine;

public class RecycleBucket : MonoBehaviour
{
    private bool objectIsHovering;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectIsHovering = true;
        if (collision.CompareTag("Trashed") && objectIsHovering)
        {
            TrashedIngredient trashedIngredient = collision.GetComponent<TrashedIngredient>();
            if (!trashedIngredient.GetIsDragging())
            {
                Debug.Log($"{collision.name} got recycled");
                trashedIngredient.GetRecycled();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        objectIsHovering = false;
        Debug.Log($"object is not hovering on {name}");
    }
}