using System;
using UnityEngine;

public class PopularityManager : MonoBehaviour
{
    public static PopularityManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private int popularity;
    public int Popularity => popularity;

    [Header("References")]
    [SerializeField] private RectTransform canvasRect; // RectTransform milik Canvas (atau Panel container)
    [SerializeField] private GameObject uiPrefab; // Prefab UI yang ingin di-spawn
    [SerializeField] private Transform worldTarget; // Objek 2D di world tempat spawn
    [SerializeField] private Camera mainCamera;


    public event Action OnPopularityChanged;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    public void IncreasePopularity(int value)
    {
        popularity += value;
        popularity = Mathf.Clamp(popularity, 0, 100);
        OnPopularityChanged?.Invoke();
    }
    public void DecreasePopularity(int value)
    {
        popularity -= value;
        OnPopularityChanged?.Invoke();
    }

    public void ClampPopularity()
    {
        popularity = Mathf.Clamp(popularity, 0, 100);
        OnPopularityChanged?.Invoke();
    }

    public GameObject SpawnUIAtWorldPosition(Transform fromPos)
    {
        worldTarget = fromPos;

        // 1. Konversi posisi World ke Screen Point
        Vector2 screenPoint = mainCamera.WorldToScreenPoint(worldTarget.position);

        // 2. Hitung posisi lokal terhadap Canvas
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPoint,
            canvasRect.GetComponent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera,
            out localPoint
        );

        // 3. Instantiate prefab sebagai child dari Canvas
        GameObject newUIObj = Instantiate(uiPrefab, canvasRect);

        // 4. Set posisi anchoredPosition objek UI yang baru dibuat
        RectTransform rectTransform = newUIObj.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = localPoint;
        }

        return newUIObj;
    }
}
