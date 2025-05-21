using UnityEngine;

/*
 *  Nombre comportamiento: Zona de llegada
 *  Caso de uso: Se usa para iniciar en un lugar desde el lugar de origen
 *  Datos de entrada: jugador, la camara, dirección donde mira, lugar donde aparece
 *  Datos de salida: jugador aparece mirando en la misma dirección donde mira en el nuevo lugar.
 *  Precondiciones: Haber ingresado a una zona controlada por GoToNewPlace
 */

public class SpawnZone : MonoBehaviour
{
    private PlayerController thePlayer; // Variable para referenciar al controlador del jugador.
    private CameraFollow theCamera; // Variable para referenciar al script que hace que la cámara siga al jugador.
    public Vector2 facingDirection = Vector2.zero; // Dirección hacia la que el jugador debe mirar al aparecer.
    public string placeName; // Nombre del lugar donde el jugador aparecerá.

    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();
        theCamera = FindFirstObjectByType<CameraFollow>();

        if (thePlayer != null && theCamera != null)
        {
            if (!thePlayer.nextPlaceName.Equals(placeName))
            {
                return;
            }

            thePlayer.transform.position = transform.position;
            theCamera.transform.position = new Vector3(
                transform.position.x, transform.position.y, theCamera.transform.position.z);

            thePlayer.lastMovement = facingDirection; // Ahora accesible sin restricciones.
        }
    }
}