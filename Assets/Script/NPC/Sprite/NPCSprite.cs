using UnityEngine;

public class NPCSprite : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;
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

    public void RotateAtLastNode(Transform point)
    {
        transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                point.rotation,
                rotationSpeed * Time.deltaTime
            );
    }
}
