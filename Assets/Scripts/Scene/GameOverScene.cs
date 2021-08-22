using UnityEngine;
using Utils;

namespace Scene
{
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
}