using System.Collections.Generic;
using UnityEngine;

public class NPCChooseMenu : MonoBehaviour
{
    [SerializeField] private List<MenuSO> allMenuCanBeOrdered = new List<MenuSO>();

    private void CheckTheMenu()
    {
        if(StatisticManager.instance.CurrentEvents.Count == 0)
        {
            //LiatMenunya
        }
        else
        {

        }
    }
}
