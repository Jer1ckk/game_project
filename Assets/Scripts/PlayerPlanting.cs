using UnityEngine;

public class PlayerPlanting : MonoBehaviour
{
    public float interactRange = 2f;   // how close you must be
    public LayerMask farmLandLayer;    // assign in Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPlant();
        }
    }

    void TryPlant()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactRange, farmLandLayer);

        foreach (var hit in hits)
        {
            FarmLand farm = hit.GetComponent<FarmLand>();

            if (farm != null && farm.IsEmpty())
            {
                farm.PlantTomato();
                return; // stop after planting one
            }
        }

        Debug.Log("No empty farmland nearby.");
    }
}
