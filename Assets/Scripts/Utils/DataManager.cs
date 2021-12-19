using Data;
using UnityEngine;

namespace Utils
{
    public static class DataManager
    {
        private const string BestScoreOnePlayerKey = "bso";
        private const string BestScoreTwoPlayerKey = "bst";
        private const string CurrentScoreKey = "cs";

        public static void SaveBestScore(int score)
        {
            switch (Configs.GameMode)
            {
                case GameMode.OnePlayer:
                    SaveOnePlayerBestScore(score);
                    break;

                case GameMode.TwoPlayer:
                    SaveTwoPlayerBestScore(score);
                    break;
            }
        }

        public static int GetBestScore()
        {
            switch (Configs.GameMode)
            {
                case GameMode.OnePlayer:
                    return GetOnePlayerBestScore();

                case GameMode.TwoPlayer:
                    return GetTwoPlayerBestScore();

                default:
                    return 0;
            }
        }

        private static void SaveOnePlayerBestScore(int value) => Save(BestScoreOnePlayerKey, value);
        public static int GetOnePlayerBestScore() => Get(BestScoreOnePlayerKey, 0);
        private static void SaveTwoPlayerBestScore(int value) => Save(BestScoreTwoPlayerKey, value);
        public static int GetTwoPlayerBestScore() => Get(BestScoreTwoPlayerKey, 0);

        public static void SaveCurrentScore(int value) => Save(CurrentScoreKey, value);
        public static int GetCurrentScore() => Get(CurrentScoreKey, 0);

        private static void Save(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }

        private static void Save(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }

        private static void Save(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }

        private static int Get(string key, int defaultValue) => PlayerPrefs.GetInt(key, defaultValue);
    }
}