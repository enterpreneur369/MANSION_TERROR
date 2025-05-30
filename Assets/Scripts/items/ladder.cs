using UnityEngine;

public class ladder : MonoBehaviour
{
    public string itemName = "ladder"; // Nombre único del ítem

    private void Start()
    {
        if (ItemsPool.Instance.HasItem(itemName))
        {
            Debug.Log($"Item {itemName} already collected, destroying game object.");
            Destroy(gameObject); // Si el ítem ya ha sido recogido, no se muestra
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ItemsPool.Instance.AddItem(itemName);
            Destroy(gameObject); // Elimina el objeto al recogerlo
        }
    }
}