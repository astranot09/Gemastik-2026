using NUnit.Framework;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private Transform[] points;
    private int currPoint;
    [SerializeField] private float speed;
    private TablePath assignedTable;
    private bool isGoingHome = false;

    private void Update()
    {
        if (points == null || currPoint >= points.Length)
            return;

        Transform target = points[currPoint];

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
                //ReachTable();
                GetOut();
            }
        }
    }

    public void GetTable(TablePath table)
    {
        assignedTable = table;
        points = table.GetPoints();
        currPoint = 0;
    }

    public void GetOut()
    {
        isGoingHome = true;
        currPoint = points.Length - 1;
        assignedTable.Vacate();
    }
}
