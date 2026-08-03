using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    [SerializeField] private GameObject NPCPrefab;
    [SerializeField] private Transform spawnPoint;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnNPC()
    {
        TablePath table = TableManager.instance.GetTable();
        if (table == null)
        {
            Debug.Log("No available tables.");
            return;
        }
        GameObject NPC = Instantiate(NPCPrefab, spawnPoint.position, Quaternion.identity);
        PathFinding pathFinding = NPC.GetComponent<PathFinding>();
        pathFinding.GetTable(table);
    }
}
