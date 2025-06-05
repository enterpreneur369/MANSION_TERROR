using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Arrastra desde el Inspector las referencias a los paneles correspondientes
    public GameObject pausePanel;
    public GameObject controlsPanel;

    private static  PauseMenuController  instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // Evitar que este objeto se destruya al cambiar de escena.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destruye duplicados si se carga el mismo Canvas en otra escena
            Destroy(gameObject);
        }
    }


    // Llama este método al presionar el botón de "Control"
    public void ShowControls()
    {
        // Mostrar el panel de controles
        if (controlsPanel != null)
            controlsPanel.SetActive(true);

        // Opcional: ocultar el panel de pausa
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    // Si deseas poder volver, por ejemplo, teniendo un botón en el panel de controles
    public void BackToPause()
    {
        // Oculta el panel de controles
        if (controlsPanel != null)
            controlsPanel.SetActive(false);

        // Vuelve a mostrar el panel de pausa
        if (pausePanel != null)
            pausePanel.SetActive(true);
        Time.timeScale = 1f;
    

}
}