using Data;
using UnityEngine.SceneManagement;

namespace Utils
{
    public static class SceneLoader
    {

        public static void LoadNextScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public static void LoadMainMenu()
        {
            LoadScene("Menu");
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

                    // case GameMode.Online:
                    //     LoadLocalGame();
                    //     break;
            }
        }

        public static void LoadGameResult()
        {
            LoadScene("GameResult");
        }

        private static void LoadLocalGame()
        {
            LoadScene("LocalGame");
        }

        public static void LoadStatistic()
        {
            LoadScene("Statistic");
        }

        public static void LoadAbout()
        {
            LoadScene("About");
        }

        private static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}