using Data;
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
                    LoadLocalGame();
                    break;

                case GameMode.TwoPlayer:
                    LoadLocalGame();
                    break;

                case GameMode.Online:
                    LoadLocalGame();
                    break;
            }
        }

        public static void LoadOnlineGame()
        {
            LoadScene("OnlineGame");
        }

        public static void LoadGameOver()
        {
            LoadScene("GameOver");
        }

        private static void LoadLocalGame()
        {
            LoadScene("LocalGame");
        }

        private static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}