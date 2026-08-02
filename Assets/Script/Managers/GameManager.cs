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

    //Event
    public event Action NewDayStart;

    public void NextDay()
    {
        day++;
        NewDayStart?.Invoke();
    }
}
