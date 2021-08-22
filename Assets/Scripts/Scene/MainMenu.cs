using Data;
using UnityEngine;
using Utils;

namespace Scene
{
    public class MainMenu : MonoBehaviour
    {
        public void OnOnePlayerClicked()
        {
            Configs.GameMode = GameMode.OnePlayer;
            SceneLoader.LoadLevelSelect();
        }

        public void OnTwoPlayerClicked()
        {
            Configs.GameMode = GameMode.TwoPlayer;
            SceneLoader.LoadLevelSelect();
        }

        public void OnExitClicked()
        {
            Application.Quit();
        }
    }
}