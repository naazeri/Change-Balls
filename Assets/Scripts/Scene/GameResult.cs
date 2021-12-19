using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scene
{
    public class GameResult : MonoBehaviour
    {
        [SerializeField] private Text bestScoreText;
        [SerializeField] private Text currentScoreText;

        private void Start()
        {
            UpdateScores();
        }

        private void UpdateScores()
        {
            bestScoreText.text = $"Best Score: {DataManager.GetBestScore()}";
            currentScoreText.text = $"Current Score: {DataManager.GetCurrentScore()}";
        }

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