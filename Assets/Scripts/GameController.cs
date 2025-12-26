using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int currentDay = 1;
    public int harvestedToday = 0;
    public int dailyTarget = 12; // starting target

    public Transform playerSpawnPoint; // assign in Inspector

    public DayCompleteUI dayCompleteUI; // assign in inspector

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Call this when a plant is harvested
    public void RegisterHarvest()
    {
        harvestedToday++;
        Debug.Log($"Harvested today: {harvestedToday}/{dailyTarget}");

        if (harvestedToday >= dailyTarget)
        {
            if (dayCompleteUI != null)
                dayCompleteUI.ShowDayComplete();
        }
    }

    // Start a new day
    public void StartNextDay()
    {
        currentDay++;
        harvestedToday = 0;
        dailyTarget += 6; // increase target for next day
        Debug.Log($"🌅 Day {currentDay} started. Target = {dailyTarget}");

        // Move player to spawn point
        if (PlayerController.instance != null && playerSpawnPoint != null)
        {
            CharacterController controller = PlayerController.instance.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false; // disable to move player manually
                PlayerController.instance.transform.position = playerSpawnPoint.position;
                controller.enabled = true; // re-enable controller
            }
            else
            {
                PlayerController.instance.transform.position = playerSpawnPoint.position;
            }
        }
    }

}
