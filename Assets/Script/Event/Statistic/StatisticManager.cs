using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatisticEventType
{
    None,
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

    [SerializeField] private StatisticEventType currentEvent;
    [SerializeField] private StatisticEventType currentEvent2;


}
