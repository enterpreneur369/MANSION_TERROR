using UnityEngine;

public class CarolinaMission : MonoBehaviour
{
    // Nombre del ítem requerido para la misión.
    public string requiredItem = "Key";

    // Mensajes de diálogo para la misión.
    public string[] missionDialog = new string[]
    {
        "Carolina: ¡Oh, encuentras la llave! ¿Me la entregas?",
        "Carolina: Que valiente, podremos ir al Baile juntos.",
        "Misión completada."
    };

    // Bandera para asegurarnos de que la misión solo se complete una vez.
    private bool missionCompleted = false;

    // Referencias a otros gestores necesarios.
    private DialogManager dialogManager;
    private ItemsPool itemsPool;
    private InventoryManager inventoryManager;

    void Start()
    {
        // Busca las instancias en la escena. Se asume que hay un único DialogManager, ItemsPool e InventoryManager.
        dialogManager = FindFirstObjectByType<DialogManager>();
        itemsPool = FindFirstObjectByType<ItemsPool>();
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    // Cuando el jugador (con etiqueta "Player") entra en el trigger, se comprueba la misión.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (missionCompleted)
            return;

        if (collision.CompareTag("Player"))
        {
            // Verificamos si el jugador tiene la llave
            if (itemsPool != null && itemsPool.HasItem(requiredItem))
            {
                // Muestra el diálogo de misión y luego remueve la llave y marca la misión como completada.
                if (dialogManager != null)
                {
                    dialogManager.ShowDialog(missionDialog);
                }

                // Remueve la llave del ItemsPool.
                itemsPool.RemoveItem(requiredItem);

                // También puedes removerla del InventoryManager si lo requieres según tu implementación.
                // Por ejemplo, si usas un método RemoveItem() que acepte el nombre:
                // inventoryManager.RemoveItem(requiredItem);

                missionCompleted = true;

                // Opcionalmente, desactiva el GameObject de Carolina para indicar que la misión ya se completó.
                gameObject.SetActive(false);
            }
            else
            {
               
            }
        }
    }
}