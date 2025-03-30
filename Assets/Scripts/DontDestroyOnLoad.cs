using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Nombre comportamiento: No destruir cuando se cargue en el mapa
 *  Caso de uso: Se usa para persistir ciertos elementos en diferentes escenas: jugador, camara, hud, misiones.
 *  Datos de entrada: El padre que no se debería borrar al cargar la escena.
 *  Datos de salida: Mostrar el game objet en la nueva escena.
 *  Precondiciones: Haberle colocado el script al game object que se desea persistir entre escenas.
 */

public class DontDestroyOnLoad : MonoBehaviour
{
    // Awake se llama antes de la primera actualización del primer frame
    void Awake()
    {
        // Verifica si el jugador ya fue creado
        if (!PlayerController.playerCreated)
        {
            // Si el jugador no ha sido creado, marca este objeto para no ser destruido al cargar una nueva escena
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            // Si el jugador ya existe, destruye este objeto para evitar duplicados
            Destroy(gameObject);
        }
    }
}
