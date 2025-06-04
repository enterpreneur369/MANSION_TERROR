using UnityEngine;

public class HouseFront : MonoBehaviour
{
    public string placeName; // Por ejemplo, "HouseFront"

    private void Start()
    {
        PlayerController playerController = FindFirstObjectByType<PlayerController>();
        if (playerController != null && playerController.nextPlaceName.Equals(placeName))
        {
            // Posiciona al jugador en el spawn point
            playerController.transform.position = transform.position;
        }
    }
}