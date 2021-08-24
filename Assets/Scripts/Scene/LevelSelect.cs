using Data;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scene
{
    public class LevelSelect : MonoBehaviour
    {
        [SerializeField] private Text speedText;
        [SerializeField] private Slider slider;

        public void OnStartClicked()
        {
            Configs.Speed = slider.value;
            SceneLoader.LoadGameplay();
        }

        public void OnSliderValueChange()
        {
            var sliderValue = (int) (slider.value * 10);
            speedText.text = sliderValue.ToString();
        }
    }
}