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

}
