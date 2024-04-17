using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog; // Array de cadenas que almacena los diálogos del NPC.

    private DialogManager _dialogManager; // Referencia privada al gestor de diálogos.

    private bool _playerInTheZone; // Variable booleana que indica si el jugador está en la zona de interacción.

    // Start se llama antes de la primera actualización del frame.
    void Start()
    {
        _dialogManager = FindObjectOfType<DialogManager>(); // Busca en la escena un objeto de tipo DialogManager y lo asigna a _dialogManager.
        
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
