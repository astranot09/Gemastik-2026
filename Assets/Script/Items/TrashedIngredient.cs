using UnityEngine;

public class TrashedIngredient : MonoBehaviour
{
    private bool isDragging = false;
    private SpriteRenderer spriteRenderer;
    private Vector2 prevPosition;
    private CapsuleCollider2D capsuleCollider;
    private Vector2 size;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        prevPosition = transform.position;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    public void Initialize(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        size = capsuleCollider.size;
    }

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapCapsule(transform.position, size, capsuleCollider.direction, 0f, layerMask);
        Debug.Log(hit);
        if (isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        prevPosition = transform.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void GetTrashed()
    {
        Debug.Log("Trashed");
        Destroy(gameObject);
    }

    public void GetRecycled()
    {
        Debug.Log("Recycled");
        Destroy(gameObject);
    }

    public bool GetIsDragging()
    {
        return isDragging;
    }
}
