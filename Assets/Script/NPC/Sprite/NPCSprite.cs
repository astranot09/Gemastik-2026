using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class NPCSprite : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private SpriteLibraryAsset[] NPCLibraryAssets;
    private SpriteLibrary library;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        library = GetComponent<SpriteLibrary>();
    }

    private void Start()
    {
        library.spriteLibraryAsset = NPCLibraryAssets[UnityEngine.Random.Range(0, NPCLibraryAssets.Length)];
    }

    public void RotateSprite(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, 0, angle + 90f);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    public void IsWalking(bool isWalking)
    {
        animator.SetBool("IsWalking", isWalking);
        Debug.Log($"Is Walking = {isWalking}");
    }

    public void RotateAtLastNode(Transform point)
    {
        transform.rotation = point.rotation;
    }
}
