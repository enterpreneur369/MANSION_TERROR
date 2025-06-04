using UnityEngine;
using UnityEngine.UI;

public class ActionsManager : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    
    public GameObject lintern;
    private bool onLintern = false;

    void Start()
    {
        _inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    public void GiveAction()
    {
        Debug.Log("Soltar");

        if (_inventoryManager.HasItem(1)) // 1 = Hueso
        {
            Dog dog = FindFirstObjectByType<Dog>(); // Busca al perro en la escena

            if (dog != null && dog.IsPlayerInZone()) // Verifica si el jugador está en la zona del perro.
            {
                _inventoryManager.RemoveItem(1); // Remueve el hueso del inventario.
                dog.GiveBoneToDog(); // Llama al método del perro.
            }
        }
    }

    public void UseAction()
    {
        Debug.Log("ACCION USAR");

        if (_inventoryManager.HasItem(0)) // 0 = Linterna
        {
            onLintern = !onLintern;
            lintern.SetActive(onLintern);
        }
    }
}