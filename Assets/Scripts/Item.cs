using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        // Aquí se inicializaría el objeto si fuera necesario
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Aquí se podrían realizar comprobaciones o actualizaciones constantes del objeto
    }

    // Esta función se llama cuando otro collider entra en contacto con este objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que colisionó tiene la etiqueta "Player"
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject); // Destruye este objeto
            //gameObject.SetActive(false); // Otra opción sería desactivar el objeto en lugar de destruirlo
        }
    }
}
