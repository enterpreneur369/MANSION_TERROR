using UnityEngine;

public class SpawnInWorld : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamera;
    public GameObject lintern; // Referencia a la linterna, si es necesaria

    void Start()
    {
        // Busca la linterna en la escena por nombre. Asegúrate de que el nombre coincida con el de tu linterna.
        lintern = GameObject.Find("LinternLight");
        if (lintern != null)
        {
            lintern.SetActive(false); // Desactiva la linterna al inicio
        }

        thePlayer = FindFirstObjectByType<PlayerController>();
        theCamera = FindFirstObjectByType<CameraFollow>();

        if (thePlayer != null && theCamera != null)
        {
            // Obtiene la posición de spawn según si el jugador tiene la llave o no.
            Vector2 spawnPoint = GetFixedSpawnPoint();

            thePlayer.transform.position = spawnPoint;
            theCamera.transform.position = new Vector3(spawnPoint.x, spawnPoint.y, theCamera.transform.position.z);
        }
    }

    private Vector2 GetFixedSpawnPoint()
    {
        // Verifica si el jugador tiene la llave en su inventario. 
        // Esto asume que itemsPool es persistente y dispone de HasItem().
        if (ItemsPool.Instance != null && ItemsPool.Instance.HasItem("Key"))
        {
            // Si el jugador tiene la llave, se busca el objeto del spawn point "HouseFront".
            GameObject houseFront = GameObject.Find("HouseFront");
            if (houseFront != null)
            {
                return houseFront.transform.position;
            }
        }

        // Si no se cumple la condición anterior, se recupera la posición fija guardada en PlayerPrefs.
        float x = PlayerPrefs.GetFloat("FixedSpawnX", 2.57f);
        float y = PlayerPrefs.GetFloat("FixedSpawnY", -4.54f);
        return new Vector2(x, y);
    }
}