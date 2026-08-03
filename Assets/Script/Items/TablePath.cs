using UnityEngine;

public class TablePath : MonoBehaviour
{
    [SerializeField] private GameObject pointsContainer;
    private Transform[] Points;
    public bool IsOccupied { get; private set; }


    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        int child = pointsContainer.transform.childCount;
        Points = new Transform[child];
        for (int i = 0; i < child; i++)
        {
            Points[i] = pointsContainer.transform.GetChild(i);
        }
        IsOccupied = false;
    }

    public void Occupy()
    {
        IsOccupied = true;
    }

    public void Vacate()
    {
        IsOccupied = false;
    }

    public Transform[] GetPoints()
    {
        return Points;
    }
}
