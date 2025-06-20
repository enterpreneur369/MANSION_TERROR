using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Nombre comportamiento: Item coleccionable
 *  Caso de uso: Se usa para tener la mecánica de obtener items
 *  Datos de entrada: El item a coleccionar
 *  Datos de salida: Destrucción del item luego de obtenido
 *  Precondiciones: Estar en la zona del item a recolectar.
 */

public class Item : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name, 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "Player"
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerPrefs.SetInt(gameObject.name, 1);
            PlayerPrefs.Save();

            //Destroy(gameObject); // Destruye este objeto
            gameObject.SetActive(false); // Otra opción sería desactivar el objeto en lugar de destruirlo
        }
    }
}
