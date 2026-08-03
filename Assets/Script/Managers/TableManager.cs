using UnityEngine;

public class TableManager : MonoBehaviour
{
    public static TableManager instance;
    private TablePath[] tables;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        tables = FindObjectsByType<TablePath>(FindObjectsSortMode.None);
    }

    public TablePath GetTable()
    {
        foreach (var table in tables)
        {
            if (table.IsOccupied == false)
            {
                table.Occupy();
                return table;
            }
        }
        return null;
    }
}
