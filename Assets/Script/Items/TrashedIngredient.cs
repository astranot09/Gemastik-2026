using UnityEngine;

public class TrashedIngredient : MonoBehaviour
{
    private bool isDragging = false;
    private string ingredientName;
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

    public void Initialize(IngredientSO ingredient)
    {
        Debug.Log($"Sprite = {ingredient.name}");
        Sprite sprite = ingredient.ingredientSprite;

        spriteRenderer.sprite = sprite;
        ingredientName = ingredient.ingredientName;

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
        Debug.Log(hit.name);
        if (hit)
        {
            prevPosition = transform.position;
        }
        else
        {
            ReturnToPosition();
        }
    }

    public void GetTrashed()
    {
        Debug.Log("Trashed");
        AudioManager.instance.PlaySFX(AudioManager.instance.minigameCorrect);
        Destroy(gameObject);
    }

    public void GetRecycled()
    {
        Debug.Log("Recycled");
        AudioManager.instance.PlaySFX(AudioManager.instance.minigameCorrect);
        Destroy(gameObject);
    }

    public string GetName()
    {
        return ingredientName;
    }

    public bool GetIsDragging()
    {
        return isDragging;
    }

    public void ReturnToPosition()
    {
        transform.position = prevPosition;
    }
}
