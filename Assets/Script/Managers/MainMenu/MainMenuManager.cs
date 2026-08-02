using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject settingPanel;

    public void StartGame()
    {
        SceneController.instance.GameScene();
    }

    public void SettingButton()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }


    public void ExitGame()
    {
        SceneController.instance.ExitGame();
    }
}
