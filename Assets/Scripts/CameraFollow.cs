using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase se encarga de hacer que la cámara siga a un objeto dentro del juego.
public class CameraFollow : MonoBehaviour
{
    // Objeto que la cámara seguirá.
    public GameObject followTarget;
    // Posición objetivo hacia la que se moverá la cámara.
    [SerializeField] private Vector3 targetPosition;
    // Velocidad a la que se moverá la cámara para alcanzar su objetivo.
    [SerializeField] private float cameraSpeed = 4.0f;
    // Start se llama antes del primer frame update. Aquí se inicializarían variables si fuera necesario.
    void Start()
    {
        
    }

    // Update se llama una vez por frame. Aquí se maneja la lógica de seguimiento de la cámara.
    void Update()
    {
        // Se actualiza la posición objetivo de la cámara para que siga al objeto objetivo.
        // Se mantiene la misma posición en el eje z de la cámara.
        targetPosition = new Vector3(followTarget.transform.position.x,
            followTarget.transform.position.y,
            this.transform.position.z);
        // Se mueve suavemente la posición de la cámara hacia la posición objetivo usando interpolación lineal.
        // Esto crea un efecto de movimiento suave.
        this.transform.position = Vector3.Lerp(this.transform.position,
            targetPosition,
            cameraSpeed * Time.deltaTime);
    }
}
