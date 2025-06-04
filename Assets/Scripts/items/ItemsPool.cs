using System.Collections.Generic;
using UnityEngine;

public class ItemsPool : MonoBehaviour
{
    public static ItemsPool Instance; // Singleton para acceso global
    private HashSet<string> collectedItems = new HashSet<string>(); // Almacenar nombres únicos de ítems

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            Debug.Log($"Item added: {itemName}"); // Log para depuración
            Debug.Log("Current items in the pool: " + string.Join(", ", collectedItems));

        }
    }
    public void ClearItems()
    {
        collectedItems.Clear();
        Debug.Log("ItemsPool has been cleared.");
    }
    public bool HasItem(string itemName)
    {
        return collectedItems.Contains(itemName);
    }
    public bool HasLadder()
    {
        Debug.Log("Checking for ladder in items pool.");
        return HasItem("ladder");

    }
    public void RemoveItem(string itemName)
    {
        if (collectedItems.Contains(itemName))
        {
            
            collectedItems.Remove(itemName);
            Debug.Log($"Item removed: {itemName}"); // Log para depuración
        }
        else
        {
            Debug.LogWarning($"Attempted to remove item that does not exist: {itemName}");
        }
    }
}