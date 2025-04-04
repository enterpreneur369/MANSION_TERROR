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
        if (inventoryObject.CompareTag("Item"))
        {
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
        Debug.Log("El item seleccionado es: " + ID);
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