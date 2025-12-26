using UnityEngine;
using TMPro;

public class DayCompleteUI : MonoBehaviour
{
    public GameObject panel;          // assign DayCompletePanel
    public TMP_Text dayCompleteText;  // assign DayCompleteTextTMP

    void Start()
    {
        panel.SetActive(false); // hide at start
    }

    public void ShowDayComplete()
    {
        if (GameController.Instance != null)
        {
            int day = GameController.Instance.currentDay;
            int target = GameController.Instance.dailyTarget;
            dayCompleteText.text = $"Day {day} Complete!\nTarget was {target} tomatoes";
        }

        panel.SetActive(true);

        // Unlock and show cursor so UI can be clicked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Optional: pause the game
        Time.timeScale = 0f;
    }


    public void GoToNextDay()
    {
        panel.SetActive(false);

        // Lock and hide cursor for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f; // resume game

        if (GameController.Instance != null)
            GameController.Instance.StartNextDay();
    }

}
