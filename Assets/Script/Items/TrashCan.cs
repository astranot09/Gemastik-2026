using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashed"))
        {
            TrashedIngredient trashedIngredient = collision.GetComponent<TrashedIngredient>();
            if (!trashedIngredient.GetIsDragging())
            {
                Debug.Log($"{collision.name} got trashed");
                trashedIngredient.GetTrashed();
            }
            
        }
    }
}
