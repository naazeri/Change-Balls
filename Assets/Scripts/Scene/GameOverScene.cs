using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    public void OnPlayAgainButtonClicked()
    {
        SceneLoader.LoadGameplay();
    }

    public void OnMenuButtonClicked()
    {
        SceneLoader.LoadMainMenu();
    }
}