using System;
using UnityEngine;

/*
 *  Nombre comportamiento: Gestión para items de misión
 *  Caso de uso: Se usa para gestionar el comportamiento del objeto de misión
 *  Datos de entrada: el id que identifica la misión relacionada con el objeto
 *  Datos de salida: indica si el objeto de misión fue recolectado para completar la misión de recoleción.
 *  Precondiciones: Tener una misión de tipo recolección de objeto que es en este caso la misión principal.
 */

[RequireComponent(typeof(BoxCollider2D))]
public class QuestItem : MonoBehaviour
{
    public int questId;

    private QuestManager _questManager;

    public string itemName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _questManager = FindFirstObjectByType<QuestManager>();
        if (_questManager != null)
        {
            // Usa el questManager normalmente.
        }
        else
        {
            Debug.LogError("QuestManager no encontrado en la escena.");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (_questManager.quests[questId].gameObject.activeInHierarchy && !_questManager.questCompleted[questId])
            {
                _questManager.itemCollected = itemName;
                _questManager.quests[questId].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
