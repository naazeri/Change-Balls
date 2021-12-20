using System;
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
        [SerializeField] TextMeshProUGUI _speedSliderValueText;
        [SerializeField] TextMeshProUGUI _frameRateSliderValueText;
        [SerializeField] Slider _speedSlider;
        [SerializeField] Slider _frameRateSlider;

        // statistic
        [SerializeField] TextMeshProUGUI _statisticBestScoreOnePlayerText;
        [SerializeField] TextMeshProUGUI _statisticBestScoreTwoPlayerText;

        // game result
        [SerializeField] TextMeshProUGUI _gameResultBestScoreText;
        [SerializeField] TextMeshProUGUI _gameResultCurrentScoreText;

        private void Awake()
        {
            UpdateFrameRate(DataManager.GetFrameRate());
        }

        private void UpdateFrameRate(int fps)
        {
            Application.targetFrameRate = fps;
            _frameRateSlider.value = fps;
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
        public void OnSpeedSliderValueChange()
        {
            var sliderValue = (int)(_speedSlider.value * 10);
            _speedSliderValueText.text = sliderValue.ToString();
            Configs.Speed = _speedSlider.value;
        }

        /*** Setting Menu ***/
        public void OnFrameRateSliderValueChange()
        {
            int sliderValue = (int)_frameRateSlider.value;
            _frameRateSliderValueText.text = sliderValue.ToString();
        }

        public void OnSettingSaveClicked()
        {
            int fps = (int)_frameRateSlider.value;
            DataManager.SaveFrameRate(fps);
            UpdateFrameRate(fps);
        }

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