using UnityEngine;

public class RecycleBucket : MonoBehaviour
{
    private bool objectIsHovering;
    private TrashedIngredient hoveringIngredient;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashed"))
        {
            objectIsHovering = true;
            hoveringIngredient = collision.GetComponent<TrashedIngredient>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryRecycle();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashed"))
        {
            objectIsHovering = false;
            hoveringIngredient = null;
        }
    }

    public void TryRecycle()
    {
        if (objectIsHovering && hoveringIngredient != null)
        {
            if (!hoveringIngredient.GetIsDragging())
            {
                Debug.Log($"{hoveringIngredient.name} got Recycled");
                hoveringIngredient.GetRecycled();
                MinigameManager.instance.CheckTrash();
            }
        }
    }
}