namespace Data
{
    public static class Configs
    {
        public static float Speed = 7.0f;
        public static GameMode GameMode = GameMode.OnePlayer;

        
    }
    
    public enum GameMode
    {
        OnePlayer,
        TwoPlayer,
        Online
    }
}