using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChoosingMenuPrefab : MonoBehaviour
{
    [SerializeField] private MenuSO menuSO;
    [SerializeField] private bool isSelected;

    [Header("UI")]
    [SerializeField] private Image menuIcon;
    [SerializeField] private TMP_Text menuName;
    [SerializeField] private Image buttonImage;

    public void InitMenu(MenuSO menu)
    {
        menuSO = menu;
        isSelected = false;
        menuIcon.sprite = menuSO.menuSprite;
        menuName.text = menuSO.menuName;
    }
    public void OnChoose()
    {
        if (!isSelected && ChoosingMenu.instance.CurrentSelected < ChoosingMenu.instance.MaxMenuCanBeSelected)
        {
            isSelected = true;
            ChoosingMenu.instance.AddSelectedMenu(menuSO);
            buttonImage.color = Color.grey;
        }
        else if (isSelected)
        {
            isSelected = false;
            ChoosingMenu.instance.RemoveSelectedMenu(menuSO);
            buttonImage.color = Color.white;
        }
    }

    public void OpenDescription()
    {
        ChoosingMenu.instance.OpenDescriptionMenu(menuSO);
    }
}
