using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private PlayerController thePlayer; // Variable para referenciar al controlador del jugador.
    private CameraFollow theCamera; // Variable para referenciar al script que hace que la cámara siga al jugador.
    public Vector2 facingDirection = Vector2.zero; // Dirección hacia la que el jugador debe mirar al aparecer.
    public string placeName; // Nombre del lugar donde el jugador aparecerá.
    
    // Start se llama antes de la primera actualización del frame.
    void Start()
    {   
        thePlayer = FindObjectOfType<PlayerController>(); // Busca en la escena el objeto que tiene el script PlayerController y lo asigna a thePlayer.
        theCamera = FindObjectOfType<CameraFollow>(); // Busca en la escena el objeto que tiene el script CameraFollow y lo asigna a theCamera.
        if (null != theCamera && null != theCamera) // Verifica que tanto theCamera como thePlayer no sean nulos.
        {
            if (!thePlayer.nextPlaceName.Equals(placeName)) // Comprueba si el lugar al que el jugador va a aparecer no coincide con placeName.
            {
                return; // Si no coincide, termina la ejecución del método.
            }

            thePlayer.transform.position = this.transform.position; // Establece la posición del jugador en la posición de este objeto.
            theCamera.transform.position = new Vector3(
                this.transform.position.x, this.transform.position.y, theCamera.transform.position.z); // Mueve la cámara para que siga al jugador, manteniendo su posición en el eje z.

            thePlayer.lastMovement = facingDirection; // Establece la última dirección de movimiento del jugador a la dirección especificada por facingDirection.
        }
    }
}
