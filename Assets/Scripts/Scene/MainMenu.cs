using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnOnePlayerClicked()
    {
        Configs.gameMode = Configs.GameMode.OnePlayer;
        SceneLoader.LoadLevelSelect();
    }

    public void OnTwoPlayerClicked()
    {
        Configs.gameMode = Configs.GameMode.TwoPlayer;
        SceneLoader.LoadLevelSelect();
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}