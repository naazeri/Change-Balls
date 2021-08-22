using UnityEngine;

public class Configs : MonoBehaviour
{
    public static float Speed = 7.0f;
    public static GameMode gameMode = GameMode.OnePlayer;

    public enum GameMode
    {
        OnePlayer,
        TwoPlayer,
        Online
    }
}