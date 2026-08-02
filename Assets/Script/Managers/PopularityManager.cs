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


    public void IncreasePopularity(int value)
    {
        popularity += value;
        popularity = Mathf.Clamp(popularity, 0, 100);
    }
    public void DecreasePopularity(int value)
    {
        popularity -= value;
        popularity = Mathf.Clamp(popularity, 0, 100);
    }



}
