using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Order
{
    public MenuSO menu;
    public NPCChooseMenu npc;
    public List<Transform> path;

    public Order (MenuSO menuSO, NPCChooseMenu from, List<Transform> pathOrder)
    {
        this.menu = menuSO;
        this.npc = from;
        this.path = pathOrder;
    }
}

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private List<Order> orderList = new();

    [Header("Food")]
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Transform foodTransform;


    [Header("Setting Coroutine")]
    [SerializeField] private float delayPerCooking = 2f;
    [SerializeField] private float delayPerOrder = 0.5f;
    Coroutine orderCoroutine;

    public void AddOrdered(MenuSO menu, NPCChooseMenu from, List<Transform> pathOrder)
    {
        // FIX 1: Masukkan order ke list
        Order order = new Order(menu, from, pathOrder);
        orderList.Add(order);

        // FIX 2: Jalankan Coroutine antrean jika belum berjalan
        StartOrderCoroutine();
    }


    public void CheckOrdered(MenuSO menu, NPCChooseMenu from, List<Transform> pathOrder)
    {
        if (InventoryManager.Instance != null)
        {
            bool cukupSemuaIngredient = true;
            foreach (IngredientSO ingredient in menu.listIngredient)
            {
                if (!InventoryManager.Instance.TryToCheckIngredient(ingredient, 1))
                {
                    cukupSemuaIngredient = false;
                    break;
                }
            }

            if (cukupSemuaIngredient)
            {
                AcceptOrdered(menu,from, pathOrder);
            }
            else
            {
                CanceledOrdered(from);
            }
        }
    }

    public void StartOrderCoroutine()
    {
        if(orderCoroutine == null)
        {
            orderCoroutine = StartCoroutine(OrderCoroutine());
        }
    }

    private IEnumerator OrderCoroutine()
    {
        while (orderList.Count > 0)
        {
            yield return new WaitForSeconds(delayPerOrder);

            Order currentOrder = orderList[0];
            orderList.RemoveAt(0);

            CheckOrdered(currentOrder.menu, currentOrder.npc, currentOrder.path);
        }

        // Reset reference coroutine jika antrean sudah habis
        orderCoroutine = null;
    }


    public void CanceledOrdered(NPCChooseMenu from)
    {
        from.NPCDisappointed();
    }

    public void AcceptOrdered(MenuSO menu, NPCChooseMenu from, List<Transform> pathOrder)
    {
        foreach(IngredientSO ingredientSO in menu.listIngredient)
        {
            InventoryManager.Instance.RemoveTheIngredientFromInventory(ingredientSO,1);
        }

        StartCoroutine(SpawnFood(menu, from, pathOrder));
    }

    public IEnumerator SpawnFood(MenuSO menu, NPCChooseMenu from, List<Transform> pathOrder)
    {
        yield return new WaitForSeconds(delayPerCooking);
        GameObject x = Instantiate(foodPrefab, foodTransform.position, Quaternion.identity);
        x.GetComponent<FoodToNPC>().SetUpFood(menu.menuSprite, pathOrder);

        if (RecapManager.instance != null)
        {
            RecapManager.instance.AddRecapMenu(menu);
        }
    }

}
