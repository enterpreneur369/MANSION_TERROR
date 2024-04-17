using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
