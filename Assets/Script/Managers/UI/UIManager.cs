using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject confirmationPanel;

    [Header("Inventory")]
    [SerializeField] private GameObject inventoryPanel;

    [Header("Popularity")]
    [SerializeField] private Slider popularitySlider;

    [Header("Statistic")]
    [SerializeField] private GameObject statisticPanel;
    [SerializeField] private TMP_Text statisticText;

    [Header("Profile")]
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text currencyText;

    [Header("SCREEN")]
    [SerializeField] private CanvasGroup screenCanvasGroup;

    [Header("Bucket")]
    [SerializeField] private Slider bucketSlider;

    [Header("Reference")]
    [SerializeField] private PopularityManager popularityManager;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WasteManager wasteManager;

    private void OnEnable()
    {
        popularityManager.OnPopularityChanged += UpdatePopularityUI;
        currencyManager.OnCurrencyChanged += UpdateProfileUI;
        gameManager.OnDayStart += UpdateProfileUI;
        gameManager.OnGameStart += TurnOffScreenCanvasGroup;
        gameManager.OnDayStart += TurnOnScreenCanvasGroup;
        wasteManager.onWasteChange += UpdateBucketUI;
    }
    private void OnDisable()
    {
        popularityManager.OnPopularityChanged -= UpdatePopularityUI;
        currencyManager.OnCurrencyChanged -= UpdateProfileUI;
        gameManager.OnDayStart -= UpdateProfileUI;
        gameManager.OnGameStart -= TurnOffScreenCanvasGroup;
        gameManager.OnDayStart -= TurnOnScreenCanvasGroup;
        wasteManager.onWasteChange -= UpdateBucketUI;
    }

    private void Start()
    {
        UpdateProfileUI();
    }

    public void OpenMenuRestaurant()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    public void OpenShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    public void OpenConfirmationPanel()
    {
        confirmationPanel.SetActive(!confirmationPanel.activeSelf);
    }
    public void StartRestaurant()
    {
        confirmationPanel.SetActive(false);
        GameManager.instance.StartDay();
    }


    // ============================ POPULARITY =====================================
    public void UpdatePopularityUI()
    {
        popularitySlider.maxValue = 100;
        popularitySlider.value = popularityManager.Popularity;
    }

    // ============================ STATISTIC =====================================
    public void OpenStatisticData()
    {
        statisticPanel.SetActive(!statisticPanel.activeSelf);
        if (statisticPanel.activeSelf)
            CheckStatisticUI();
    }

    public void CheckStatisticUI()
    {
        if (StatisticManager.instance == null) return;

        List<StatisticEventType> types = StatisticManager.instance.CurrentEvents;
        switch (types.Count)
        {
            case 0:
                statisticText.text = "No Event";
                break;

            case 1:
                statisticText.text = $"- People like {types[0]}";
                break;

            case 2:
                statisticText.text = $"- People like {types[0]}\n- People like {types[1]}";
                break;
        }

    }


    //============================ PROFILE =====================================
    public void UpdateProfileUI()
    {
        if(CurrencyManager.instance == null) return;
        currencyText.text = $"Rp.{CurrencyManager.instance.Money}k / Rp.{CurrencyManager.instance.BaseTargetMoney}k";
        if(GameManager.instance == null) return;
        dayText.text = $"Day : {GameManager.instance.Day}";
    }


    // ============================ SCREEN CANVAS =====================================
    public void TurnOffScreenCanvasGroup()
    {
        screenCanvasGroup.alpha = 0;
        screenCanvasGroup.interactable = false;
        screenCanvasGroup.blocksRaycasts = false;
    }
    public void TurnOnScreenCanvasGroup()
    {
        screenCanvasGroup.alpha = 1;
        screenCanvasGroup.interactable = true;
        screenCanvasGroup.blocksRaycasts = true;
    }

    //============================ DUMP BUCKET =====================================

    public void UpdateBucketUI()
    {
        bucketSlider.maxValue = WasteManager.instance.maxWaste;
        bucketSlider.value = WasteManager.instance.currWaste;
    }
}
