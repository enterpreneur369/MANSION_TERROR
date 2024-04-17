using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ActionsManager : MonoBehaviour
{
    private InventoryManager _inventoryManager; // Variable para gestionar el inventario.

    private ActionsManager _actionsManager; // Variable para gestionar las acciones.
    public GameObject lintern; // Objeto público que representa una linterna.

    private bool onLintern = false; // Estado de la linterna, inicialmente apagada.

    // Start se llama antes del primer frame.
    void Start()
    {
        // Se buscan y asignan las instancias de InventoryManager y ActionsManager.
        _inventoryManager = FindObjectOfType<InventoryManager>();
        _actionsManager = FindObjectOfType<ActionsManager>();
    }

    // Cambia las acciones disponibles según el objeto seleccionado en el inventario.
    void ChangeActions()
    {
        // Si el primer objeto del inventario no es nulo y tiene una imagen asociada.
        if (_inventoryManager.bag[0] != null && _inventoryManager.bag[0].GetComponent<Image>().sprite)
        {
            // Selecciona las acciones disponibles según el ID del objeto en el inventario.
            switch (_inventoryManager.ID)
            {
                case 0:
                    // Habilita el primer botón y deshabilita los otros dos.
                    _actionsManager.GetComponentsInChildren<Button>()[0].interactable = true;
                    _actionsManager.GetComponentsInChildren<Button>()[1].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[2].interactable = false;
                    break;
                case 1:
                    // Habilita el tercer botón y deshabilita los primeros dos.
                    _actionsManager.GetComponentsInChildren<Button>()[0].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[1].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[2].interactable = true;
                    break;
                case 2:
                case 3:
                    // Para los casos 2 y 3, realiza la misma acción que el caso 0.
                    _actionsManager.GetComponentsInChildren<Button>()[0].interactable = true;
                    _actionsManager.GetComponentsInChildren<Button>()[1].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[2].interactable = false;
                    break;
            } 
        }
    }

    // Ejecuta una acción según el objeto seleccionado en el inventario.
    public void UseAction()
    {
        // Si el objeto seleccionado en el inventario no es nulo y tiene una imagen asociada.
        if (_inventoryManager.bag[_inventoryManager.ID] != null && 
            _inventoryManager.bag[_inventoryManager.ID].GetComponent<Image>().sprite)
        {
            // Ejecuta una acción según el ID del objeto.
            switch (_inventoryManager.ID)
            {
                case 0:
                    // Si la linterna está apagada, la enciende; si está encendida, la apaga.
                    if (!onLintern)
                    {
                        lintern.SetActive(true);
                        onLintern = true;
                    }
                    else
                    {
                        lintern.SetActive(false);
                        onLintern = false;
                    }
                    break;
            }
        }
    }

    // Métodos para acciones de dar y capturar, actualmente vacíos.
    public void GiveAction()
    {
        
    }

    public void CatchAction()
    {
        
    }

    // Update se llama una vez por frame.
    void Update()
    {
        // Llama a ChangeActions para actualizar las acciones disponibles.
        ChangeActions();
    }
}
