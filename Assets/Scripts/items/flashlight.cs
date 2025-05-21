using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public string itemName = "Flashlight"; // Nombre único del ítem

    private void Start()
    {
        if (ItemsPool.Instance.HasItem(itemName))
        {
            Destroy(gameObject); // Si el ítem ya ha sido recogido, no se muestra
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ItemsPool.Instance.AddItem(itemName);
            Destroy(gameObject); // Elimina el objeto al recogerlo
        }
    }
}