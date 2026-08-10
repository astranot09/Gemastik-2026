using System.Collections;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    [SerializeField] private Sprite[] randomIngredientList;
    [SerializeField] private GameObject minigamePanel;
    [SerializeField] private GameObject trashedPrefab;
    [SerializeField] private GameObject trashedParent;
    [SerializeField] private int numberOfTrash;
    [SerializeField] private BoxCollider2D spawnArea;
    [SerializeField] private float secondsBeforeClose;

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
            Instantiate(trashedPrefab, randomPosition, Quaternion.identity, trashedParent.transform);
        }
    }

    public void CheckTrash()
    {
        Debug.Log(trashedParent.transform.childCount - 1);
        if (trashedParent.transform.childCount - 1 <= 0)
        {
            CloseMinigame();
        }
    }

    public void OpenMinigame()
    {
        minigamePanel.SetActive(true);
        SpawnTrashed();
    }

    public void CloseMinigame()
    {
        StartCoroutine(StartClose());
    }

    IEnumerator StartClose()
    {
        yield return new WaitForSeconds(secondsBeforeClose);
        WasteManager.instance.MinigameBucketFinished();
        minigamePanel.SetActive(false);
    }
}
