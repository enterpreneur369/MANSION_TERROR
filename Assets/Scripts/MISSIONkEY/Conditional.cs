using UnityEngine;

public class Conditional : MonoBehaviour
{
    public ItemsPool itemsPool; // Referencia al inventario
    public string requiredItem = "Key";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (itemsPool.HasItem(requiredItem))
            {
                ShowMessage("Puedes avanzar");
            }
            else
            {
                Debug.Log("Tienes la llave?");
            }
        }
    }

    private void ShowMessage(string message)
    {
        // Implementa tu sistema de UI para mostrar mensajes al jugador.
        Debug.Log(message); // Se usa Debug.Log como ejemplo
    }
}
