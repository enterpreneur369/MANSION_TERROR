using UnityEngine;

/*
 *  Nombre comportamiento: Lógica para crear una misión personalizada
 *  Caso de uso: Se usa para crear una misión personalizada con un texto de inicio y de fin de misión.
 *  Datos de entrada: el id que identifica la misión, un mensaje inicial y uno final
 *  Datos de salida: Se mostrará un mensaje cuando inicie una misión y finalize.
 *  Precondiciones: Haber iniciado o terminado una misión.
 */

public class Quest : MonoBehaviour
{
    public int questID;
    public string startText, completeText;
    public QuestManager questManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartQuest()
    {
        questManager.ShowQuestText(startText);
    }

    public void CompleteQuest()
    {
        questManager.ShowQuestText(completeText);
        questManager.questCompleted[questID] = true;
        gameObject.SetActive(false);
    }
}
