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
    [SerializeField] private int maxWasteInBucket = 5;
    [SerializeField] private int popularityDecreaseValue = 2;

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
    }


    public bool CheckBucket(IngredientSO ingredientSO)
    {
        if(currentWasteInBucket < maxWasteInBucket && ingredientSO.ingredientName != "Daging")
        {
            currentWasteInBucket++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RefreshBucket()
    {
        currentWasteInBucket = 0;
    }
}
