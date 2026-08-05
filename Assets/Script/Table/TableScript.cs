using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    [SerializeField] private List<Transform> foodPathList = new List<Transform>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            collision.GetComponent<NPCChooseMenu>().SitAtTable(new List<Transform>(foodPathList));
        }
    }
    
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("NPC"))
    //    {
    //        collision.GetComponent<NPCChooseMenu>().LeaveTable();
    //    }
    //}
}
