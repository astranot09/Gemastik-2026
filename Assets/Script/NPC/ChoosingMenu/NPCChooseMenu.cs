using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCChooseMenu : MonoBehaviour
{
    [SerializeField] private List<MenuSO> availableRestaurantMenu = new List<MenuSO>();
    [SerializeField] private List<MenuSO> allMenuCanBeOrdered = new List<MenuSO>();

    private void Start()
    {
        CheckListRestaurantMenu();
    }

    public void CheckListRestaurantMenu()
    {
        availableRestaurantMenu.Clear();
        allMenuCanBeOrdered.Clear();
        availableRestaurantMenu = ChoosingMenu.instance.MenuSelected;
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

        // Optional fallback: If no items match active events, fall back to full menu so NPCs don't starve!
        if (allMenuCanBeOrdered.Count == 0)
        {
            allMenuCanBeOrdered = new List<MenuSO>(availableRestaurantMenu);
        }
    }

    public MenuSO GetRandomChoice()
    {
        if (allMenuCanBeOrdered.Count == 0) CheckTheMenu();
        if (allMenuCanBeOrdered.Count == 0) return null;

        int randomIndex = Random.Range(0, allMenuCanBeOrdered.Count);
        return allMenuCanBeOrdered[randomIndex];
    }

}
