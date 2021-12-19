using UnityEngine;
using Utils;

public class About : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenSiteUrl()
    {
        Application.OpenURL("https://naazeri.ir/");
    }
    public void OnMenuButtonClicked()
    {
        SceneLoader.LoadMainMenu();
    }
}
