using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCChooseMenu : MonoBehaviour
{
    [SerializeField] private List<MenuSO> availableRestaurantMenu = new List<MenuSO>();
    [SerializeField] private List<MenuSO> allMenuCanBeOrdered = new List<MenuSO>();


    [Header("Status")]
    [SerializeField] private bool lookedMenu = false;
    [SerializeField] private List<Transform> foodPathList;

    [Header("Setting")]
    [SerializeField] private int decreasePopularityValue = 5;

    [Header("Reference")]
    [SerializeField] private PathFinding pathFinding;

    public void SitAtTable(List<Transform> foodPath)
    {
        foodPathList = foodPath;
        CheckListRestaurantMenu();
    }


    public void CheckListRestaurantMenu()
    {
        availableRestaurantMenu.Clear();
        allMenuCanBeOrdered.Clear();
        if (ChoosingMenu.instance != null && ChoosingMenu.instance.MenuSelected != null)
        {
            availableRestaurantMenu = new List<MenuSO>(ChoosingMenu.instance.MenuSelected);
        }
        CheckTheMenu();
    }

    public void CheckTheMenu()
    {
        allMenuCanBeOrdered = new List<MenuSO>(availableRestaurantMenu);

        List<StatisticEventType> activeEvents = StatisticManager.instance.CurrentEvents;

        // If there are active event modifiers, filter the orderable menu
        if (activeEvents != null && activeEvents.Count > 0)
        {
            // Keep only menus that have AT LEAST ONE tag matching today's active events
            allMenuCanBeOrdered = allMenuCanBeOrdered
                .Where(menu => menu != null && menu.statisticEventType.Any(tag => activeEvents.Contains(tag)))
                .ToList();
        }

        if (allMenuCanBeOrdered.Count == 0)
        {
            NPCDisappointed();
        }
        else
        {
            NPCHappyEatFood();
        }
        
    }

    public MenuSO GetRandomChoice()
    {
        if (allMenuCanBeOrdered.Count == 0) CheckTheMenu();
        if (allMenuCanBeOrdered.Count == 0) return null;

        int randomIndex = Random.Range(0, allMenuCanBeOrdered.Count);
        return allMenuCanBeOrdered[randomIndex];
    }

    public void NPCDisappointed()
    {
        Debug.Log("Ga ada makanannya :(");
        if(PopularityManager.instance != null)
        {
            PopularityManager.instance.DecreasePopularity(decreasePopularityValue);
        }
        StartCoroutine(NPCLeaveRestaurant());
    }
    public void NPCHappyEatFood()
    {
        MenuSO x = GetRandomChoice();
        Debug.Log(x.ToString());

        if(OrderManager.instance != null)
        {
            OrderManager.instance.AddOrdered(x, this, foodPathList);
        }
    }


    public void LeaveTable()
    {
        foodPathList.Clear();
    }

    IEnumerator NPCLeaveRestaurant()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("NPC GW PERGI >:(");
        pathFinding.WantToGetOut();
    }

}
