namespace Data
{
    public static class Configs
    {
        public static float Speed = 10.0f;
        public static GameMode GameMode = GameMode.OnePlayer;
        public static string SiteURL = "https://nazeriland.ir";
        public static string ApiLatestGameVersionURL = $"{SiteURL}/game-api/change-balls/v1/version";
    }

    public enum GameMode
    {
        OnePlayer,
        TwoPlayer
    }
}