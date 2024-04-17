using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToNewPlace : MonoBehaviour
{
    // Define el nombre de la nueva escena a cargar
    public string newPlaceName = "New Scene Value";
    // Define el nombre del lugar al que el jugador va a ir
    public string goToPlaceName;

    // Este método se llama cuando otro collider entra en contacto con este objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "Player"
        if (collision.gameObject.tag.Equals("Player"))
        {
            // Encuentra el controlador del jugador y establece su próxima ubicación de destino
            FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
            // Carga la nueva escena basada en el nombre proporcionado
            SceneManager.LoadScene(newPlaceName);
        }
    }
}
