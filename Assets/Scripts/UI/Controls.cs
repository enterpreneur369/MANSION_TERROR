using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Arrastra desde el Inspector las referencias a los paneles correspondientes
    public GameObject pausePanel;
    public GameObject controlsPanel;

    // Llama este m�todo al presionar el bot�n de "Control"
    public void ShowControls()
    {
        // Mostrar el panel de controles
        if (controlsPanel != null)
            controlsPanel.SetActive(true);

        // Opcional: ocultar el panel de pausa
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    // Si deseas poder volver, por ejemplo, teniendo un bot�n en el panel de controles
    public void BackToPause()
    {
        // Oculta el panel de controles
        if (controlsPanel != null)
            controlsPanel.SetActive(false);

        // Vuelve a mostrar el panel de pausa
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }
}