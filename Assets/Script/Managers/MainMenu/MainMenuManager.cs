using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject settingPanel;

    public void StartGame()
    {
        SceneController.instance.CutsceneIntroScene();
    }

    public void SettingButton()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
        AudioManager.instance.PlaySFX(AudioManager.instance.uiPanelEntry);
    }


    public void ExitGame()
    {
        SceneController.instance.ExitGame();
    }
}
