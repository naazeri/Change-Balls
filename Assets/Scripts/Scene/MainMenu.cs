using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scene
{
    public class MainMenu : MonoBehaviour
    {
        // speed
        [SerializeField] TextMeshProUGUI _speedText;
        [SerializeField] Slider _speedSlider;

        // statistic
        [SerializeField] TextMeshProUGUI _statisticBestScoreOnePlayerText;
        [SerializeField] TextMeshProUGUI _statisticBestScoreTwoPlayerText;

        // game result
        [SerializeField] TextMeshProUGUI _gameResultBestScoreText;
        [SerializeField] TextMeshProUGUI _gameResultCurrentScoreText;

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
            _statisticBestScoreOnePlayerText.text = $"Best Score: {DataManager.GetOnePlayerBestScore()}";
            _statisticBestScoreTwoPlayerText.text = $"Best Score: {DataManager.GetTwoPlayerBestScore()}";
        }

        /*** Game Result ***/
        public void UpdateGameResultScores()
        {
            _gameResultBestScoreText.text = $"Best Score: {DataManager.GetBestScore()}";
            _gameResultCurrentScoreText.text = $"Current Score: {DataManager.GetCurrentScore()}";
        }
    }
}