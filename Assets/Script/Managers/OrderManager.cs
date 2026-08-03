using System.Collections.Generic;
using UnityEngine;

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


    [SerializeField] private List<NPCChooseMenu> npcScript;


    public void AddOrdered(MenuSO menu, NPCChooseMenu from)
    {
        
    }


}
