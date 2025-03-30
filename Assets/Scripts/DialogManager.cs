using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox; // Referencia al objeto que contiene el cuadro de diálogo en la UI.
    public Text dialogText; // Referencia al componente de texto donde se mostrará el diálogo.

    public bool dialogActive; // Bandera para controlar si el diálogo está activo o no.

    public string[] dialogLines; // Arreglo de cadenas que contiene las líneas de diálogo a mostrar.

    public int currentDialogLine; // Índice de la línea de diálogo actual que se está mostrando.

    private PlayerController _playerController; // El jugador que está dialogando

    // Start se llama antes de la actualización del primer frame.
    void Start()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
    }

    // Esta función se encarga de mostrar el cuadro de diálogo con el texto proporcionado.
    public void ShowDialog(string[] text)
    {
        dialogActive = true; // Activa el diálogo.
        dialogBox.SetActive(true); // Hace visible el cuadro de diálogo en la UI.
        currentDialogLine = 0; // Inicia en la primera línea de diálogo.
        dialogLines = text; // Asigna el texto proporcionado al arreglo de líneas de diálogo.
        _playerController.playerTalking = true; // Activa la bandera de que está hablando con un NPC
    }
    // Update se llama una vez por frame.
    void Update()
    {
        // Si el diálogo está activo y el jugador presiona la tecla Espacio, avanza a la siguiente línea de diálogo.
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLine++;
        }

        // Si se han mostrado todas las líneas de diálogo, desactiva el cuadro de diálogo y reinicia el índice de línea.
        if (currentDialogLine >= dialogLines.Length)
        {
            dialogActive = false; // Desactiva el diálogo.
            dialogBox.SetActive(false); // Oculta el cuadro de diálogo en la UI.
            currentDialogLine = 0; // Reinicia el índice de la línea de diálogo.
            _playerController.playerTalking = false;
        }
        else
        {
            dialogText.text = dialogLines[currentDialogLine];
        }
    }
}
