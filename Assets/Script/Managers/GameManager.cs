using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private int day = 0;

    public int Day => day;


    [Header("Setting")]
    [SerializeField] private int endOfDayPopularity = 20;
    public void NextDay()
    {
        day++;
    }
    public void EndOfDay()
    {
        EndOfDayIncreaseRestaurantPopularity();
    }




    //========================= EVENT POPULARITY ==============================
    public void EndOfDayIncreaseRestaurantPopularity()
    {
        PopularityManager.instance.IncreasePopularity(endOfDayPopularity);
    }
}
