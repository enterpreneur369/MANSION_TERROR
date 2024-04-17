using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Esta clase gestiona el inventario del jugador.
public class InventoryManager : MonoBehaviour
{
    // Lista que almacena los objetos en el inventario.
    public List<GameObject> bag = new List<GameObject>();

    // Referencia al objeto de inventario en la UI.
    public GameObject inv;

    // Referencia al selector que indica el objeto seleccionado.
    public GameObject selector;

    // ID del objeto actualmente seleccionado en el inventario.
    public int ID;
    // Start se llama antes de la primera actualización del frame.

    // Se llama cuando un objeto entra en el trigger del inventario.
    void OnTriggerEnter2D(Collider2D inventoryObject)
    {
        // Verifica si el objeto es un ítem.
        if (inventoryObject.CompareTag("Item"))
        {
            // Recorre la lista de objetos en el inventario.
            for (int i = 0; i < bag.Count; i++)
            {
                // Si encuentra un objeto desactivado (espacio vacío), lo activa y asigna el sprite del ítem recogido.
                if (bag[i].GetComponent<Image>().enabled == false)
                {
                    bag[i].GetComponent<Image>().enabled = true;
                    bag[i].GetComponent<Image>().sprite = inventoryObject.GetComponent<SpriteRenderer>().sprite;
                    break; // Sale del bucle después de asignar el ítem.
                }
            }
        }
    }

    // Gestiona la navegación por el inventario.
    void Navigate()
    {
        // Si se presiona la tecla E y no se ha llegado al final de la lista, se incrementa el ID.
        if (Input.GetKeyDown(KeyCode.E) && ID < bag.Count - 1 )
        {
            ID++;
        }

        // Si se presiona la tecla Q y el ID es mayor que 0, se decrementa el ID.
        if (Input.GetKeyDown(KeyCode.Q) && ID > 0)
        {
            ID--;
        }
        // Actualiza la posición del selector para que coincida con la del objeto seleccionado.
        selector.transform.position = bag[ID].transform.position;
    }

    void Start()
    {
    }

    // Update se llama una vez por frame.
    void Update()
    {
        // Llama a la función Navigate para gestionar la navegación por el inventario.
        Navigate();
    }
}
