using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text dayTaskText; // assign in inspector

    void Update()
    {
        if (GameController.Instance != null)
        {
            int day = GameController.Instance.currentDay;
            int harvested = GameController.Instance.harvestedToday;
            int target = GameController.Instance.dailyTarget;

            dayTaskText.text = $"Day {day}\nHarvest {harvested}/{target} tomatoes";
        }
    }
}
