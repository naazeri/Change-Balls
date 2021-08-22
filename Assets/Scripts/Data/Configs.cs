using UnityEngine;

namespace Data
{
    public class Configs : MonoBehaviour
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