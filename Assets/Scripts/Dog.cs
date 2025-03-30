using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject messagePanel; // Mensaje cuando el perro se va.
    public AudioSource dogAudio; // Audio del perro.

    private bool playerInZone = false;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>(); // Obtiene el inventario.

        if (dogAudio == null)
        {
            dogAudio = GetComponent<AudioSource>(); // Intenta obtener el AudioSource automáticamente.
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }

    public bool IsPlayerInZone()
    {
        return playerInZone;
    }

    public void GiveBoneToDog()
    {
        if (inventoryManager != null)
        {
            inventoryManager.RemoveItem(1); // 1 = Hueso
        }

        DisappearDog(); // Ejecuta la acción para hacer que el perro se vaya.
    }

    void DisappearDog()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(true); // Muestra el mensaje de que el perro se fue.
        }

        if (dogAudio != null)
        {
            dogAudio.Stop(); // Detiene el sonido del perro.
        }

        gameObject.SetActive(false); // Oculta el perro.
    }
}