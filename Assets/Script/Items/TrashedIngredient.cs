using UnityEngine;

public class TrashedIngredient : MonoBehaviour
{
    private bool isDragging = false;
    private SpriteRenderer spriteRenderer;
    private Vector2 prevPosition;
    private CapsuleCollider2D capsuleCollider;
    private Vector2 size;
    [SerializeField] LayerMask layerMask;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        prevPosition = transform.position;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    public void Initialize(Sprite sprite)
    {
        Debug.Log($"Sprite = {sprite.name}");

        spriteRenderer.sprite = sprite;

        capsuleCollider.size = new Vector3(sprite.bounds.size.x-2, sprite.bounds.size.y-3, sprite.bounds.size.z);
        capsuleCollider.direction = CapsuleDirection2D.Horizontal;
    }

    private void Update()
    {
        
        if (isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        Collider2D hit = Physics2D.OverlapCapsule(transform.position, capsuleCollider.size, capsuleCollider.direction, 0f, layerMask);
        Debug.Log(hit);
        if (hit)
        {
            prevPosition = transform.position;
        }
        else
        {
            transform.position = prevPosition;
        }
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
