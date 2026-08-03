using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecapMenuPrefab : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private RecapMenuClass recapMenuData;

    [Header("UI")]
    [SerializeField] private Image menuIcon;
    [SerializeField] private TMP_Text menuName;
    [SerializeField] private TMP_Text menuPriceCount;

    public void SetUpRecapMenuPrefab(RecapMenuClass data)
    {
        recapMenuData = data;
        menuIcon.sprite = recapMenuData.menu.menuSprite;
        menuName.text = recapMenuData.menu.menuName;
        menuPriceCount.text = $"Rp{recapMenuData.quantity * recapMenuData.menu.menuPrice}.000";
    }
}
