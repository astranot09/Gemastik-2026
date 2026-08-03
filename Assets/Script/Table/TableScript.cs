using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    [SerializeField] private List<Transform> foodPathList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            collision.GetComponent<NPCChooseMenu>().SitAtTable(foodPathList);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            collision.GetComponent<CircleCollider2D>().enabled = false;
            collision.GetComponent<NPCChooseMenu>().LeaveTable();
        }
    }
}
