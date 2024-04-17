using UnityEngine;
using UnityEngine.SceneManagement;

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
}
