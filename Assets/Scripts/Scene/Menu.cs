using Data;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Utils;

namespace Scene
{
    public class Menu : MonoBehaviour
    {
        // main menu
        // [SerializeField] TextMeshProUGUI _gameVersionText;
        // [SerializeField] GameObject _updateGameButton;

        // speed
        [SerializeField] Slider _speedSlider;
        [SerializeField] TextMeshProUGUI _speedSliderValueText;

        // settings
        [SerializeField] Slider _frameRateSlider;
        [SerializeField] TextMeshProUGUI _frameRateSliderValueText;

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

        private void Start()
        {
            // _gameVersionText.text = "Version: " + Application.version;

            //if (Application.platform != RuntimePlatform.WebGLPlayer)
            //{
            //StartCoroutine(CheckLatestGameVersion());
            //}
        }
        //private IEnumerator CheckLatestGameVersion()
        //{
        //    using (UnityWebRequest webRequest = UnityWebRequest.Get(Configs.ApiLatestGameVersionURL))
        //    {
        //        // Request and wait for the desired page.
        //        yield return webRequest.SendWebRequest();

        //        if (webRequest.isNetworkError || webRequest.isHttpError)
        //        {
        //            Debug.Log("error on getting latest game version: " + webRequest.error);
        //            yield break;
        //        }

        //        var json = JsonUtility.FromJson<VersionModel>(webRequest.downloadHandler.text);
        //        var latestVersion = json.GetLatestVersion();
        //        var currentVersion = Application.version;

        //        if (latestVersion != null && latestVersion.Length > 0 && !currentVersion.Equals(latestVersion))
        //        {
        //            _gameVersionText.text += " - New Version Available: " + latestVersion;
        //            _updateGameButton.SetActive(true);
        //        }
        //    }
        //}

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

        public void OnUpdateGameClicked()
        {
            Application.OpenURL("https://naazeri.ir/my-account/downloads/");
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

        //public void SetGraphicQuality(int qualityIndex)
        //{
        //    QualitySettings.SetQualityLevel(qualityIndex);
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