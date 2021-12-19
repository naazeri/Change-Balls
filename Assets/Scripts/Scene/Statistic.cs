using UnityEngine;
using UnityEngine.UI;
using Utils;

public class Statistic : MonoBehaviour
{
    [SerializeField] private Text bestScoreOnePlayerText;
    [SerializeField] private Text bestScoreTwoPlayerText;

    void Start()
    {
        UpdateScores();
    }

    private void UpdateScores()
    {
        bestScoreOnePlayerText.text = $"Best Score: {DataManager.GetOnePlayerBestScore()}";
        bestScoreTwoPlayerText.text = $"Best Score: {DataManager.GetTwoPlayerBestScore()}";
    }
    public void OnMenuButtonClicked()
    {
        SceneLoader.LoadMainMenu();
    }
}
