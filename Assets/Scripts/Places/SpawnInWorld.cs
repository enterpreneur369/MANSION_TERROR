using UnityEngine;

public class SpawnInWorld : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamera;

    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();
        theCamera = FindFirstObjectByType<CameraFollow>();

        if (thePlayer != null && theCamera != null)
        {
            Vector2 spawnPoint = GetFixedSpawnPoint(); // Obtiene la posición fija

            thePlayer.transform.position = spawnPoint;
            theCamera.transform.position = new Vector3(spawnPoint.x, spawnPoint.y, theCamera.transform.position.z);
        }
    }

    private Vector2 GetFixedSpawnPoint()
    {
        float x = PlayerPrefs.GetFloat("FixedSpawnX", 2.57f); // Si no hay datos, usa (0,0) por defecto
        float y = PlayerPrefs.GetFloat("FixedSpawnY", -4.54f);
        return new Vector2(x, y);
    }
}