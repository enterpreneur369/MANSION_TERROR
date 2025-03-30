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
}
