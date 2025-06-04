using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToWorld : MonoBehaviour
{
    // Nombre de la escena a cargar (World)
    public string newPlaceName = "World";
    // Nombre del spawn point en la escena World donde aparecerá el jugador
    // Este valor debe coincidir con el valor del spawn zone en World (por ejemplo "HouseFront")
    public string goToPlaceName = "HouseFront";
    // Requerimiento para avanzar (por ejemplo, la llave)
    public string requiredItem = "Key";

    private DialogManager _dialogManager;
    private QuestManager _questManager;
    private ItemsPool _inventory; // Sistema de inventario

    private void Start()
    {
        _dialogManager = FindFirstObjectByType<DialogManager>();
        _questManager = FindFirstObjectByType<QuestManager>();
        _inventory = FindFirstObjectByType<ItemsPool>(); // Obtiene la instancia del inventario
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica que la misión principal esté activa.
            if (_questManager.quests[0].gameObject.activeInHierarchy)
            {
                // Verifica que el jugador tiene la llave requerida.
                if (_inventory.HasItem(requiredItem))
                {
                    // Asigna el spawn point para el jugador.
                    PlayerController playerController = FindFirstObjectByType<PlayerController>();
                    playerController.nextPlaceName = goToPlaceName;

                    // Carga la escena World
                    SceneManager.LoadScene(newPlaceName);
                }
                else
                {
                    String[] text = new[]
                    {
                        "Parece que necesitas una llave para avanzar."
                    };
                    _dialogManager.ShowDialog(text);
                }
            }
            else
            {
                String[] text = new[]
                {
                    "Parece que no has comenzado la misión necesaria."
                };
                _dialogManager.ShowDialog(text);
            }
        }
    }
}