using System;
using System.Collections;
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

    [Header("NPC")]
    [SerializeField] private int currentNPCSpawn;
    [SerializeField] private int maxNPCSpawn;
    [SerializeField] private int NPCFinish;
    [SerializeField] private int delayPerSpawnNPC;

    //EVENT
    public event Action OnGameStart;
    public event Action OnDayStart;
    public event Action OnDayEnd;
    public void StartDay()
    {
        OnGameStart?.Invoke();
        currentNPCSpawn = 0;
        NPCFinish = 0;
        maxNPCSpawn = (day + (PopularityManager.instance.Popularity / 2));
        StartCoroutine(SpawnNPCLoopCoroutine());
    }
    public void NextDay()
    {
        day++;
        OnDayStart?.Invoke();
        StatisticManager.instance.CheckStatisticCurrentDay();
    }
    public void EndOfDay()
    {
        Debug.Log("PPPPPPPPPPPPP");
        OnDayEnd?.Invoke();
        EndOfDayIncreaseRestaurantPopularity();
    }




    //========================= EVENT POPULARITY ==============================
    public void EndOfDayIncreaseRestaurantPopularity()
    {
        PopularityManager.instance.IncreasePopularity(endOfDayPopularity);
    }

    //========================= NPC SPAWN ==============================

    IEnumerator SpawnNPCLoopCoroutine()
    {
        while(currentNPCSpawn < maxNPCSpawn)
        {
            yield return new WaitForSeconds(delayPerSpawnNPC);
            NPCManager.instance.SpawnNPC();
        }
        yield return new WaitUntil(() => NPCFinish >= maxNPCSpawn);
        yield return new WaitForSeconds(3f);
        EndOfDay();
    }
    public void NPCSpawnAtRestaurant()
    {
        currentNPCSpawn++;
    }
    public void NPCFinishAtRestaurant()
    {
        NPCFinish++;
    }
}
