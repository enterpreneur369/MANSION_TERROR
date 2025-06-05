using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New Scene Value";
    public string goToPlaceName;
    private DialogManager _dialogManager;
    private QuestManager _questManager;
    private ItemsPool _inventory; // Referencia al sistema de inventario

    public string requiredItem = "Flashlight"; // Nombre del objeto necesario para entrar

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
            if (_questManager.quests[0].gameObject.activeInHierarchy)
            {
                if (_inventory.HasItem(requiredItem)) // Verifica si el jugador tiene la linterna
                {
                    FindFirstObjectByType<PlayerController>().nextPlaceName = goToPlaceName;
                    SceneManager.LoadScene(newPlaceName);
                }
                else
                {
                    String[] text = new[]
                    {
                        "Necesitas la linterna para entrar."
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