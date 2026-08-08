using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    [SerializeField] private Sprite[] randomIngredientList;
    [SerializeField] private GameObject minigamePanel;
    [SerializeField] private GameObject trashedPrefab;
    [SerializeField] private int numberOfTrash;
    [SerializeField] private BoxCollider2D spawnArea;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnTrashed()
    {
        Bounds bounds = spawnArea.bounds;
        
        for (int i = 0; i < numberOfTrash; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
            Instantiate(trashedPrefab, randomPosition, Quaternion.identity);
        }
    }

    public void OpenMinigame()
    {
        minigamePanel.SetActive(true);
        SpawnTrashed();
    }

    public void CloseMinigame()
    {
        minigamePanel.SetActive(false);
    }
}
