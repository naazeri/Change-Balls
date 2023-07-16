namespace Data
{
    public static class Configs
    {
        public static float Speed = 7.0f;
        public static GameMode GameMode = GameMode.OnePlayer;
        public static string ApiLatestGameVersionURL = "https://naazeri.ir/game-api/change-balls/v1/version";
    }
    
    public enum GameMode
    {
        OnePlayer,
        TwoPlayer
    }
}