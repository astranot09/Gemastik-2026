using System.Collections.Generic;
using UnityEngine;

public class FoodToNPC : MonoBehaviour
{
    private int currPoint = 0;
    [SerializeField] private float speed;


    [Header("Data")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Transform> pathOrder = new List<Transform>();
    [SerializeField] private NPCChooseMenu npcScript;


    private void Update()
    {
        if (pathOrder == null || currPoint >= pathOrder.Count)
            return;
        Debug.Log("Makanan Dianter");
        Transform target = pathOrder[currPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            currPoint++;
            if (currPoint >= pathOrder.Count)
            {
                Debug.Log("Makanan sampe");
                npcScript.NPCHappyGettingFood();
                Destroy(gameObject);
                return;
            }

        }
    }


    public void SetUpFood(Sprite foodSprite, List<Transform> path, NPCChooseMenu from)
    {
        npcScript = from;
        //spriteRenderer.sprite = foodSprite;
        pathOrder.Clear();
        pathOrder = path;
    }
}
