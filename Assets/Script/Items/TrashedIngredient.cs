using UnityEngine;

public class TrashedIngredient : MonoBehaviour
{
    private bool isDragging = false;
    private void Update()
    {
        if (isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDrag()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void GetTrashed()
    {
        Debug.Log("Trashed");
    }

    public bool GetIsDragging()
    {
        return isDragging;
    }
}
