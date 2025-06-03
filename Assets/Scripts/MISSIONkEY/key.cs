using UnityEngine;

public class Key : MonoBehaviour
{
    public string requiredItem = "ladder"; // Ítem necesario para obtener la llave
    public GhostAI ghost; // Referencia al enemigo fantasma

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el jugador tiene el ítem necesario
        if (ItemsPool.Instance.HasItem(requiredItem))
        {
            ItemsPool.Instance.AddItem("key");
            Debug.Log("Object key obtained!");
            GetComponent<SpriteRenderer>().enabled = false; // Desactivar el sprite de la llave
            
            //Destroy(gameObject); // Destruir el objeto después de tomarlo
        }
        else if (!ItemsPool.Instance.HasLadder())
        {
            Debug.Log("You need a ladder to obtain the key.");
            return; // Evita que el jugador tome la llave
        }
       
   
        if (other.CompareTag("Player"))
        {
            ghost.ActivateGhost(); // Activar al fantasma
        }
    }
}

