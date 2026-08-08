using UnityEngine;

public class TrashCan : MonoBehaviour
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashed"))
        {
            objectIsHovering = false;
            hoveringIngredient = null;
        }
    }

    public void TryTrash()
    {
        if (objectIsHovering && hoveringIngredient != null)
        {
            if (!hoveringIngredient.GetIsDragging())
            {
                Debug.Log($"{hoveringIngredient.name} got trashed");
                hoveringIngredient.GetTrashed();
            }
        }
    }
}