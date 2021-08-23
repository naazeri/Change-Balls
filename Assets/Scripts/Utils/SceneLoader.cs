using Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public static class SceneLoader
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
            switch (Configs.GameMode)
            {
                case GameMode.OnePlayer:
                    LoadOnePlayer();
                    break;

                case GameMode.TwoPlayer:
                    LoadTwoPlayer();
                    break;

                case GameMode.Online:
                    break;
            }
        }

        private static void LoadOnePlayer()
        {
            LoadScene("OnePlayer");
        }

        private static void LoadTwoPlayer()
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
}