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
    public NPCDialog npcDialog;
    public Quest[] quests;
    public bool[] questCompleted;
    public string itemCollected;
    public GameObject mainquest;
    private DialogManager _dialogManager;

    // Start is called once before the first frame update


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
    public void ActivateMainQuest()
    {
        // Suponiendo que la misión principal es la primera en el arreglo.
        if (quests != null && quests.Length > 0)
        {
            if (!quests[0].gameObject.activeInHierarchy)
            {
                quests[0].gameObject.SetActive(false);
                quests[0].StartQuest();  // Si tu clase Quest tiene un método de inicialización, puedes llamarlo.
                Debug.Log("Misión principal reactivada.");
                // Asegúrate de que el objeto de la misión principal esté activo.

            }
        }
    }
    // MÉTODO RESET: reinicia el estado de las misiones.
    public void ResetQuests()
    {
        mainquest.SetActive(false);
        // Reinicia el estado de todas las misiones a "no completadas".
        for (int i = 0; i < questCompleted.Length; i++)
        {
            
            questCompleted[i] = false;
        }                // Limpia la variable que almacena algún ítem recogido (si es parte del estado de la misión)
        itemCollected = string.Empty;
        Debug.Log("Todas las misiones han sido reiniciadas.");
    }
}