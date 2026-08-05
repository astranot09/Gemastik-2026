using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private Transform[] points;
    private int currPoint;
    [SerializeField] private float speed;
    private TablePath assignedTable;
    private bool isGoingHome = false;
    private bool reachTable = true;

    [Header("Reference")]
    [SerializeField] private NPCChooseMenu chooseMenu;
    [SerializeField] private NPCSprite spriteScript;

    private void Update()
    {
        if (points == null || currPoint >= points.Length)
            return;

        Transform target = points[currPoint];

        Vector2 direction = (target.position - transform.position).normalized;
        spriteScript.RotateSprite(direction);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            if (isGoingHome)
            {
                currPoint--;
                if (currPoint < 0)
                {
                    Destroy(gameObject);
                    return;
                }
            }
            else
            {
                currPoint++;
            }

            if (currPoint >= points.Length)
            {
                if (!reachTable)
                {
                    GetOut();
                }
                    
                else if (reachTable)
                {
                    ReachTable();

                }

            }
        }
    }

    public void GetTable(TablePath table)
    {
        assignedTable = table;
        points = table.GetPoints();
        currPoint = 0;
    }

    public void ReachTable()
    {
        spriteScript.RotateAtLastNode(points[currPoint-1].transform);
        chooseMenu.CheckListRestaurantMenu();
    }

    public void WantToGetOut()
    {
        Debug.Log("Selesai");
        reachTable = false;
        GameManager.instance.NPCFinishAtRestaurant();
        GetOut();
    }

    public void GetOut()
    {
        Debug.Log("Keluar");
        isGoingHome = true;
        currPoint = points.Length - 1;
        assignedTable.Vacate();
    }
}
