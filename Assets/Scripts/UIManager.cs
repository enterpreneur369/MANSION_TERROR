using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void GoToFirstCinematic()
    {
        SceneManager.LoadScene("Cinematic");
        //SceneManager.LoadScene("World");
        // Pending to implement
    }

    public void GoToWorld()
    {
        SceneManager.LoadScene("World");
    }
    
    public void GoToMainUI()
    {
        SceneManager.LoadScene("MainUI");
    }

    public void GoToControlsUI()
    {
        SceneManager.LoadScene("ControlsUI");
    }
    
    public void GoToWindows()
    {
        Application.Quit();
    }
}
