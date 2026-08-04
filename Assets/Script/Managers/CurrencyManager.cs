using System;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private int money;
    public int Money => money;

    [Header("Challenge")]
    [SerializeField] private int baseTargetMoney;
    public int BaseTargetMoney => baseTargetMoney;
    [SerializeField] private int multiplicationTargetMoney = 5;

    public event Action OnCurrencyChanged;

    [Header("Reference")]
    [SerializeField] private GameManager gameManager;


    private void OnEnable()
    {
        gameManager.OnDayStart += CheckTargetOnNextDay;
    }

    private void OnDisable()
    {
        gameManager.OnDayStart -= CheckTargetOnNextDay;
    }


    public void AddMoney(int value)
    {
        money += value;
        OnCurrencyChanged?.Invoke();
    }

    public void RemoveMoney(int value)
    {
        money -= value;
        OnCurrencyChanged?.Invoke();
    }

    public bool CheckingBalance(int value)
    {
        return value <= Money;
    }

    public void CheckTarget()
    {
        if(Money < baseTargetMoney)
        {
            Debug.Log("Lose");
            if(LoseManager.instance != null)
            {
                LoseManager.instance.PlayerLose();
            }
            return;
        }
        else
        {
            Debug.Log("Lanjut");
            UpdateTargetCurrency();
        }
    }

    public void UpdateTargetCurrency()
    {
        baseTargetMoney *= multiplicationTargetMoney;
        OnCurrencyChanged?.Invoke();
    }


    public void CheckTargetOnNextDay()
    {
        Debug.Log("TESS"); 
        if(GameManager.instance != null)
        {
            if(GameManager.instance.Day % 5 == 1 && GameManager.instance.Day != 1)
            {
                CheckTarget();
            }
        }
    }


}
