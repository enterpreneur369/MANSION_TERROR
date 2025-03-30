using UnityEngine;

/*
 *  Nombre comportamiento: Adminsitrador de misiones
 *  Caso de uso: Se usa administrar la asignación de misiones y los mensajes que mostrará
 *  Datos de entrada: mensajes de inicio y fin de mision 
 *  Datos de salida: Mostrar usando el administrador de dialogo los mensajes relacionados con misiones.
 *  Precondiciones: Tener alguna misión activa.
 */

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public bool[] questCompleted;
    public string itemCollected;

    private DialogManager _dialogManager; 
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questCompleted = new bool[quests.Length];
        _dialogManager = FindFirstObjectByType<DialogManager>();
    }

    public void ShowQuestText(string questText)
    {
        string[] dialogLines = new string[]
        {
            questText
        };
        _dialogManager.ShowDialog(dialogLines);
    }
}
