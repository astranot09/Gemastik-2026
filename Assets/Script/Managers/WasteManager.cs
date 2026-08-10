using System;
using UnityEngine;

public class WasteManager : MonoBehaviour
{

    public static WasteManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    //[SerializeField] private int waste;
    //public int Waste => waste;

    [Header("Bucket")]
    [SerializeField] private int currentWasteInBucket = 0;
    public int currWaste => currentWasteInBucket;
    [SerializeField] private int maxWasteInBucket = 5;
    public int maxWaste => maxWasteInBucket;
    [SerializeField] private int popularityDecreaseValue = 2;

    [Header("Refresh")]
    [SerializeField] private int dayRefresh = 5;
    [SerializeField] private int currRefresh = 0;

    [Header("Minigame")]
    [SerializeField] private bool onRefresh;
    [SerializeField] private bool minigameCanBeTrigger;


    [Header("Dialogue")]
    [SerializeField] private DialogueSO bucketTutorial;
    private bool firstTimeDialogue = false;


    public event Action onWasteChange;

    public void WasteIngredient(int value, IngredientSO ingredientSO)
    {
        for (int i = 0; i < value; i++)
        {
            if (!CheckBucket(ingredientSO))
            {
                if (PopularityManager.instance != null)
                    PopularityManager.instance.DecreasePopularity(popularityDecreaseValue);
            }
        }

        if(currentWasteInBucket >= maxWasteInBucket && !minigameCanBeTrigger)
        {
            minigameCanBeTrigger = true;
            if (!firstTimeDialogue && !GameManager.instance.gameEnd)
            {
                firstTimeDialogue = true;
                DialogueManager.instance.PlayDialogue(bucketTutorial);
            }
        }
    }


    public bool CheckBucket(IngredientSO ingredientSO)
    {
        if(currentWasteInBucket < maxWasteInBucket && ingredientSO.ingredientName != "Daging")
        {
            currentWasteInBucket++;
            onWasteChange?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckDay()
    {
        if (!onRefresh) return;

        if(GameManager.instance != null)
        {

            currRefresh++;
            if(currRefresh >= dayRefresh)
            {
                RefreshBucket();
                onWasteChange?.Invoke();
            }
        }
            
    }


    public void RefreshBucket()
    {
        onRefresh = false;
        currentWasteInBucket = 0;
    }


    //Buat pasang di buttonS
    public void PlayMinigameBucket()
    {
        Debug.Log("Ga bisa");
        if (minigameCanBeTrigger)
        {
            Debug.Log("Main");
            minigameCanBeTrigger = false;
            if(MinigameManager.instance != null)
            {
                MinigameManager.instance.OpenMinigame();
            }
        }

    }
    public void MinigameBucketFinished()
    {
        onRefresh = true;
        currRefresh = 0;
    }
}
