using UnityEngine;

namespace Utils
{
    public class DataManager
    {
        private const string ScoreKey = "s";

        public static void SaveScore(int value) => Save(ScoreKey, value);
        public static int GetScore() => Get(ScoreKey, 0);

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