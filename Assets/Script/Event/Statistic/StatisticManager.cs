using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatisticEventType
{
    None,
    Egg,
    Spicy,
    Protein,
    Healthy,
    Warm,
}
[System.Serializable]
public class StatisticListFood
{
    public StatisticEventType type;
    public string nameEvent;
    [TextArea (3,5)]public string descriptionEvent;
    public List<MenuSO> menuSOs;
}
public class StatisticManager : MonoBehaviour
{
    public static StatisticManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    public List<StatisticListFood> allStatisticEvent;

    [SerializeField] private int maxEvent;
    [SerializeField] private List<StatisticEventType> currentEvents = new();
    public List<StatisticEventType> CurrentEvents => currentEvents;

    [SerializeField] private int refreshEvent = 3;
    [SerializeField] private int currEventLeft;

    private void Start()
    {
        CheckStatisticCurrentDay();
    }
    public void CheckStatisticCurrentDay() //Setiap ganti day check ini
    {
        int day = GameManager.instance.Day; //Masukkin yang itung day

        if (day == 3)
        {
            currentEvents.Add(StatisticEventType.Egg);
            currEventLeft = 1;
            return;
        }
        else if(day == 4)
        {
            currEventLeft--;
            currentEvents.Clear();
            return;
        }

        if (day < 8) return;
        else if (day >= 8 && currEventLeft == 0)
        {
            currEventLeft = refreshEvent;
            AddEventStatisticIntoList();
        }
        else
        {
            currEventLeft--;
        }
    }

    public int RandomValueForEventSpawn()
    {
        return UnityEngine.Random.Range(1, maxEvent + 1);
    }

    public void AddEventStatisticIntoList()
    {
        currentEvents.Clear();

        // Get all enum values except 'None'
        Array enumValues = Enum.GetValues(typeof(StatisticEventType));
        List<StatisticEventType> availableTypes = new List<StatisticEventType>();

        foreach (StatisticEventType type in enumValues)
        {
            if (type != StatisticEventType.None && type != StatisticEventType.Egg)
            {
                availableTypes.Add(type);
            }
        }

        // Pick unique random event types
        for (int i = 0; i < RandomValueForEventSpawn(); i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, availableTypes.Count);
            currentEvents.Add(availableTypes[randomIndex]);

            // Remove picked element to guarantee uniqueness
            availableTypes.RemoveAt(randomIndex);
        }
    }

    //public List<MenuSO> AllMenuThatSameWithEvent(List<MenuSO> currMenu)
    //{
    //    List<MenuSO> x = new List<MenuSO>();
    //    foreach (MenuSO menu in allStatisticEvent) {
    //}
}
