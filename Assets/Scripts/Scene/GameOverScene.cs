using System;
using Data;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scene
{
    public class GameOverScene : MonoBehaviour
    {
        [SerializeField] private Text titleText;
        [SerializeField] private Text bestScoreText;
        [SerializeField] private Text currentScoreText;

        private void Start()
        {
            if (Configs.GameMode == GameMode.OnePlayer)
            {
                titleText.text = "Game Over";
            }
            else if (Configs.GameMode == GameMode.TwoPlayer)
            {
                titleText.text = "White Win";
            }
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