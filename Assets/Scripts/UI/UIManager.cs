using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 *  Nombre comportamiento: Administrar el traslado entre escenas
 *  Caso de uso: Se usa para moverse entre escenas, salir de juego o pausarlo
 *  Datos de entrada: llamado directo a la escena que se requiere cargar
 *  Datos de salida: carga de escena directa o pausa del juego
 *  Precondiciones: Estar en un menú
 */

public class UIManager : MonoBehaviour
{
    // Este método carga la escena llamada "World".
    public void GoToWorld()
    {
        SceneManager.LoadScene("World");
        Time.timeScale = 1f;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        
        PlayerPrefs.SetFloat("FixedSpawnX", 2.57f); 
        PlayerPrefs.SetFloat("FixedSpawnY", -4.54f);
        if (ItemsPool.Instance != null)
        {
            ItemsPool.Instance.ClearItems(); // Nuevo método para limpiar el inventario
            //Destroy(ItemsPool.Instance.gameObject); // Elimina el objeto persistente
           // ItemsPool.Instance = null;
        }
        FindFirstObjectByType<InventoryManager>()?.ClearInventory();
    }

    // Este método carga la escena llamada "MainUI".
    public void GoToMainUI()
    {
        SceneManager.LoadScene("MainUI");
    }
    
    // Este método carga la escena llamada "Cinematic".
    public void GoToCinematic()
    {
        SceneManager.LoadScene("Cinematic");
        

    }

    // Este método carga la escena llamada "ControlsUI".
    public void GoToControlsUI()
    {
        SceneManager.LoadScene("ControlsUI");
    }
    
    // Este método cierra la aplicación.
    public void GoToWindows()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        GameObject.FindWithTag("pauseMenu").gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StopGame()
    {
        
        Time.timeScale = 0f;
        
    }

    public void QuitGame()
    {
        // Guardar el estado del juego antes de salir
        PlayerPrefs.Save();
        Debug.Log("Juego guardado al salir.");
#if UNITY_EDITOR
        // Detiene el modo de juego en el Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Cierra la aplicación en builds compiladas
            Application.Quit();
#endif
    }


}
