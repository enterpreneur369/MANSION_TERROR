using System;
using UnityEngine;

/*
 *  Nombre comportamiento: Gestionar los diálogos del NPC
 *  Caso de uso: Se usa para mostrar una conversación con el NPC
 *  Datos de entrada: los diálogos que dirá el NPC y también la misión principal asociada.
 *  Datos de salida: Se mostrará un mensaje de conversación y de la misión principal
 *  Precondiciones: Haber ingresado a la zona del NPC y luego salido de esta.
 */

public class NPCDialog : MonoBehaviour
{
    public string[] dialog; // Array de cadenas que almacena los diálogos del NPC.
    public int questId;
    
    private DialogManager _dialogManager; // Referencia privada al gestor de diálogos.

    private bool _playerInTheZone; // Variable booleana que indica si el jugador está en la zona de interacción.
    private QuestManager _questManager;
    
    // Start se llama antes de la primera actualización del frame.
    void Start()
    {
        _dialogManager = FindFirstObjectByType<DialogManager>(); // Busca en la escena un objeto de tipo DialogManager y lo asigna a _dialogManager.
        _questManager = FindFirstObjectByType<QuestManager>();
    }

    // Esta función se llama cuando otro collider entra en contacto con este collider en 2D.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "Player".
        if (collision.gameObject.tag.Equals("Player"))
        {
            _playerInTheZone = true; // Establece _playerInTheZone en verdadero si el jugador entra en la zona.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!_questManager.questCompleted[questId])
            {
                if (!_questManager.quests[questId].gameObject.activeInHierarchy)
                {
                    _questManager.quests[questId].gameObject.SetActive(true);
                    _questManager.quests[questId].StartQuest();
                }
            }
        }
    }

    // Update se llama una vez por frame.
    void Update()
    {
        // Verifica si el jugador está en la zona y si se presiona la tecla Enter.
        if (_playerInTheZone && Input.GetKeyDown(KeyCode.Return))
        {
            _dialogManager.ShowDialog(dialog); // Muestra el diálogo almacenado en el array dialog a través del DialogManager.
        }
    }
}
