using UnityEngine;

public class Key : MonoBehaviour
{
    public string requiredItem = "ladder"; // �tem necesario para obtener la llave

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el jugador tiene el �tem necesario
        if (ItemsPool.Instance.HasItem(requiredItem))
        {
            ItemsPool.Instance.AddItem("key");
            Debug.Log("Object key obtained!");
            Destroy(gameObject); // Destruir el objeto despu�s de tomarlo
        }
        else
        {
            Debug.Log("You need a ladder to obtain the key.");
        }
    }
}
