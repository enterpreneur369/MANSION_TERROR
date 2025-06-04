using System;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject messagePanel; // Mensaje cuando el perro se va.
    public AudioSource dogAudio; // Audio del perro.
    private DialogManager _dialogManager;
    private bool playerInZone = false;
    private InventoryManager inventoryManager;
    private ItemsPool ItemsPool; // Pool de ítems para verificar si el hueso ha sido recogido.

    void Start()
    {
        _dialogManager = FindFirstObjectByType<DialogManager>();
        inventoryManager = FindFirstObjectByType<InventoryManager>(); // Obtiene el inventario.

        if (dogAudio == null)
        {
            dogAudio = GetComponent<AudioSource>(); // Intenta obtener el AudioSource automáticamente.
        }
        // Verifica si el estado del perro ha sido guardado
        if (PlayerPrefs.GetInt("Dog", 0) == 1) // 0 es el valor por defecto si no se ha guardado nada
        {
            gameObject.SetActive(false); // Oculta el perro si ya se ha ido
        }
        ItemsPool = FindFirstObjectByType<ItemsPool>(); // Obtiene el pool de ítems.
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
        if (inventoryManager != null && ItemsPool != null )
        {
            if (ItemsPool.HasItem("bone")) // Verifica si el hueso (ID: 1) está en ItemsPool
            {
                inventoryManager.RemoveItem(1); // Remueve el hueso del inventario
                ItemsPool.RemoveItem("bone"); // Remueve el hueso del pool de ítems
                DisappearDog(); // Hace que el perro se vaya
            }
            else
            {
                Debug.Log("El perro necesita un hueso, pero no está en el pool de ítems.");
                String[] text = new[]
                    {
                        "Traeme un hueso, o me comere los tuyos! jaja"
                    };
                _dialogManager.ShowDialog(text);
            }
        }
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
        PlayerPrefs.SetInt("Dog", 1); // Guarda el estado de que el perro se ha ido.
    }
}