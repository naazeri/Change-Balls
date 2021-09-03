using UnityEngine;

namespace Utils
{
    public static class DataManager
    {
        private const string BestScoreKey = "bs";
        private const string CurrentScoreKey = "cs";

        public static void SaveBestScore(int value) => Save(BestScoreKey, value);
        public static int GetBestScore() => Get(BestScoreKey, 0);

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