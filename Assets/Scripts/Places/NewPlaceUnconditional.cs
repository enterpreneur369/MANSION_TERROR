using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  Nombre comportamiento: Ir a alg�n lugar
 *  Caso de uso: Se usa moverse entre el mundo principal y las diferentes habitaciones de la casa.
 *  Datos de entrada: lugar al que va a ir el personaje, dialogo, misi�n.
 *  Datos de salida: enviar al lugar requerido, validar si se tiene la misi�n principal y mostrar mensaje en caso
 * que no.
 *  Precondiciones: Tener un trigger con este script y asignarle las propiedades.
 */

public class NewPlaceUnconditional: MonoBehaviour
{
    // Define el nombre de la nueva escena a cargar
    public string newPlaceName = "New Scene Value";
    // Define el nombre del lugar al que el jugador va a ir
    public string goToPlaceName;


    private void Start()
    {
        
    }

    // Este m�todo se llama cuando otro collider entra en contacto con este objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto con el que colision� tiene la etiqueta "Player"
        if (collision.gameObject.tag.Equals("Player"))
        {
            
                // Encuentra el controlador del jugador y establece su pr�xima ubicaci�n de destino
                FindFirstObjectByType<PlayerController>().nextPlaceName = goToPlaceName;
                // Carga la nueva escena basada en el nombre proporcionado
                SceneManager.LoadScene(newPlaceName);
            
        }
    }
}
