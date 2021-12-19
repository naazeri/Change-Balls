using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _speedText;
        [SerializeField] Slider _speedSlider;

        [SerializeField] TextMeshProUGUI _bestScoreOnePlayerText;
        [SerializeField] TextMeshProUGUI _bestScoreTwoPlayerText;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        /*** Main Menu ***/
        public void OnOnePlayerClicked()
        {
            Configs.GameMode = GameMode.OnePlayer;
            //SceneLoader.LoadLevelSelect();
        }

        public void OnTwoPlayerClicked()
        {
            Configs.GameMode = GameMode.TwoPlayer;
            //SceneLoader.LoadLevelSelect();
        }



        public void OnExitClicked()
        {
            Application.Quit();
        }

        /*** Speed Menu ***/
        public void OnSliderValueChange()
        {
            var sliderValue = (int)(_speedSlider.value * 10);
            _speedText.text = sliderValue.ToString();
            Configs.Speed = _speedSlider.value;
        }

        //public void OnStartGameClicked()
        //{
        //    Configs.Speed = _speedSlider.value;
        //    //SceneLoader.LoadGameplay();
        //}

        /*** About Menu ***/
        public void OpenSiteUrl()
        {
            Application.OpenURL("https://naazeri.ir/");
        }

        /*** Statistics Menu ***/
        public void UpdateStatistics()
        {
            _bestScoreOnePlayerText.text = $"Best Score: {DataManager.GetOnePlayerBestScore()}";
            _bestScoreTwoPlayerText.text = $"Best Score: {DataManager.GetTwoPlayerBestScore()}";
        }

    }
}