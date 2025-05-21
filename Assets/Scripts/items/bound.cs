using UnityEngine;

public class bone  : MonoBehaviour
{
    public string itemName = "bone"; // Nombre �nico del �tem

    private void Start()
    {
        if (ItemsPool.Instance.HasItem(itemName))
        {
            Destroy(gameObject); // Si el �tem ya ha sido recogido, no se muestra
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