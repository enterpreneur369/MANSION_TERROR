using UnityEngine;

public class CarolinaMission : MonoBehaviour
{
    // Nombre del �tem requerido para la misi�n.
    public string requiredItem = "Key";

    // Mensajes de di�logo para la misi�n.
    public string[] missionDialog = new string[]
    {
        "Carolina: �Oh, encuentras la llave! �Me la entregas?",
        "Carolina: Que valiente, podremos ir al Baile juntos.",
        "Misi�n completada."
    };

    // Bandera para asegurarnos de que la misi�n solo se complete una vez.
    private bool missionCompleted = false;

    // Referencias a otros gestores necesarios.
    private DialogManager dialogManager;
    private ItemsPool itemsPool;
    private InventoryManager inventoryManager;

    void Start()
    {
        // Busca las instancias en la escena. Se asume que hay un �nico DialogManager, ItemsPool e InventoryManager.
        dialogManager = FindFirstObjectByType<DialogManager>();
        itemsPool = FindFirstObjectByType<ItemsPool>();
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    // Cuando el jugador (con etiqueta "Player") entra en el trigger, se comprueba la misi�n.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (missionCompleted)
            return;

        if (collision.CompareTag("Player"))
        {
            // Verificamos si el jugador tiene la llave
            if (itemsPool != null && itemsPool.HasItem(requiredItem))
            {
                // Muestra el di�logo de misi�n y luego remueve la llave y marca la misi�n como completada.
                if (dialogManager != null)
                {
                    dialogManager.ShowDialog(missionDialog);
                }

                // Remueve la llave del ItemsPool.
                itemsPool.RemoveItem(requiredItem);

                // Tambi�n puedes removerla del InventoryManager si lo requieres seg�n tu implementaci�n.
                // Por ejemplo, si usas un m�todo RemoveItem() que acepte el nombre:
                // inventoryManager.RemoveItem(requiredItem);

                missionCompleted = true;

                // Opcionalmente, desactiva el GameObject de Carolina para indicar que la misi�n ya se complet�.
                gameObject.SetActive(false);
            }
            else
            {
               
            }
        }
    }
}