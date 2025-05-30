using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> bag = new List<GameObject>();
    public GameObject inv;
    public GameObject selector;
    public int ID;

    void OnTriggerEnter2D(Collider2D inventoryObject)
    {
        if (inventoryObject.CompareTag("key"))
        {
        // Verificar si el objeto es la llave y si la escalera está en el inventario
            if (ItemsPool.Instance.HasLadder())
            {
                ItemsPool.Instance.AddItem("key");
                inventoryObject.tag = "Item"; // Cambiar la etiqueta del objeto para evitar que se recoja de nuevo
                Debug.Log("Object key obtained!");
                Destroy(inventoryObject.gameObject); // Destruir el objeto después de tomarlo
            }
            else
            {
                Debug.Log("You need a ladder to obtain the key.");
                return; // No permite tomar el object key
            }

        }
        if (inventoryObject.CompareTag("Item") )
        {
            // Verificar si el objeto es la llave y si la escalera no está en el inventario
           /* if (inventoryObject.name == "key" && !ItemsPool.Instance.HasItem("ladder"))
            {
                Debug.Log("You need a ladder to obtain the key.");
                gameObject.GetComponent<Image>().enabled = true;
                return; // No permite tomar el object key
            }*/
            
            
                // Si la condición anterior no se cumple, el ítem puede ser agregado
                for (int i = 0; i < bag.Count; i++)
                {
                    if (!bag[i].GetComponent<Image>().enabled)
                    {
                        bag[i].GetComponent<Image>().enabled = true;
                        bag[i].GetComponent<Image>().sprite = inventoryObject.GetComponent<SpriteRenderer>().sprite;
                        break;
                    }
                }
            
        }
        
    }

    void Navigate()
    {
        if (Input.GetKeyDown(KeyCode.E) && ID < bag.Count - 1)
            ID++;

        if (Input.GetKeyDown(KeyCode.Q) && ID > 0)
            ID--;

        selector.transform.position = bag[ID].transform.position;
        //Debug.Log("El item seleccionado es: " + ID);
    }

    public bool HasItem(int itemIndex)
    {
        return ID == itemIndex && bag[ID].GetComponent<Image>().enabled;
    }

    public void RemoveItem(int itemIndex)
    {
        if (HasItem(itemIndex))
        {
            bag[itemIndex].GetComponent<Image>().enabled = false;
            bag[itemIndex].GetComponent<Image>().sprite = null;
        }
    }

    void Update()
    {
        Navigate();
    }
}