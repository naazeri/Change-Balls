using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadMainMenu()
    {
        LoadScene("MainMenu");
    }

    public static void LoadLevelSelect()
    {
        LoadScene("LevelSelect");
    }

    public static void LoadGameplay()
    {
        switch (Configs.gameMode)
        {
            case Configs.GameMode.OnePlayer:
                LoadOnePlayer();
                break;

            case Configs.GameMode.TwoPlayer:
                LoadTwoPlayer();
                break;

            case Configs.GameMode.Online:
                break;
        }
    }

    public static void LoadOnePlayer()
    {
        LoadScene("OnePlayer");
    }

    public static void LoadTwoPlayer()
    {
        LoadScene("TwoPlayer");
    }

    public static void LoadGameOver()
    {
        LoadScene("GameOver");
    }

    private static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}