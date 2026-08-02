using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoseManager : MonoBehaviour
{
    public static LoseManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [Header("UI")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text dayLose;
    public void PlayerLose()
    {
        losePanel.SetActive(true);
        dayLose.text = $"Last Day = {GameManager.instance.Day.ToString()}";
    }

    public void ExitToMainMenu()
    {
        SceneController.instance.MainMenuScene();
    }

}
