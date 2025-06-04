using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    private DialogManager _dialogManager;
    public string requiredItem = "ladder"; // �tem necesario para obtener la llave
    public GhostAI ghost; // Referencia al enemigo fantasma
    private ItemsPool ItemsPool; // Pool de �tems para verificar si el jugador tiene el �tem necesario
    void Start()
    {
        _dialogManager = FindFirstObjectByType<DialogManager>();
        ItemsPool = FindFirstObjectByType<ItemsPool>(); // Obtiene la instancia del pool de �tems
        ghost = FindFirstObjectByType<GhostAI>(); // Obtiene la instancia del fantasma
        ghost.DeactivateGhost(); // Asegurarse de que el fantasma est� desactivado al inicio
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el jugador tiene el �tem necesario
        if (ItemsPool.Instance.HasItem(requiredItem))
        {
            //ItemsPool.RemoveItem("Ladder");
            ItemsPool.Instance.AddItem("Key");
            Debug.Log("Object key obtaine!");
            GetComponent<SpriteRenderer>().enabled = false; // Desactivar el sprite de la llave
            
            //Destroy(gameObject); // Destruir el objeto despu�s de tomarlo
        }
        else if (!ItemsPool.Instance.HasLadder())
        {
            String[] text = new[]
                  {
                        "Necesitas una escalera para alcanzar la llave, pero cuidado pueden haber sorpresas!!"
                    };
            _dialogManager.ShowDialog(text);
            Debug.Log("You need a ladder to obtain the key.");
            return; // Evita que el jugador tome la llave
        }
       
   
        if (other.CompareTag("Player"))
        {
            ghost.ActivateGhost(); // Activar al fantasma
        }
    }
}

