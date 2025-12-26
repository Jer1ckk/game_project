using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{
    public float waitTime = 10f;  // auto transition delay
    public string mainSceneName = "MainScene"; // your main gameplay scene
    public Button continueButton; // optional button

    void Start()
    {
        // Auto load main scene after waitTime
        Invoke("LoadMainScene", waitTime);

        // Optional: add button listener
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(() => LoadMainScene());
        }
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
