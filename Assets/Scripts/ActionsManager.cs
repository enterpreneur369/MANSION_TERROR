using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ActionsManager : MonoBehaviour
{
    private InventoryManager _inventoryManager;

    private ActionsManager _actionsManager;
    public GameObject lintern;

    private bool onLintern = false;
    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
        _actionsManager = FindObjectOfType<ActionsManager>();
    }

    void ChangeActions()
    {
        if (_inventoryManager.bag[0] != null && _inventoryManager.bag[0].GetComponent<Image>().sprite)
        {
            switch (_inventoryManager.ID)
            {
                case 0:
                    _actionsManager.GetComponentsInChildren<Button>()[0].interactable = true;
                    _actionsManager.GetComponentsInChildren<Button>()[1].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[2].interactable = false;
                    break;
                case 1:
                    _actionsManager.GetComponentsInChildren<Button>()[0].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[1].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[2].interactable = true;
                    break;
                case 2:
                    _actionsManager.GetComponentsInChildren<Button>()[0].interactable = true;
                    _actionsManager.GetComponentsInChildren<Button>()[1].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[2].interactable = false;
                    break;
                case 3:
                    _actionsManager.GetComponentsInChildren<Button>()[0].interactable = true;
                    _actionsManager.GetComponentsInChildren<Button>()[1].interactable = false;
                    _actionsManager.GetComponentsInChildren<Button>()[2].interactable = false;
                    break;
            } 
        }
    }

    public void UseAction()
    {
        if (_inventoryManager.bag[_inventoryManager.ID] != null && 
            _inventoryManager.bag[_inventoryManager.ID].GetComponent<Image>().sprite)
        {
            switch (_inventoryManager.ID)
            {
                case 0:
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

    public void GiveAction()
    {
        
    }

    public void CatchAction()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeActions();
    }
}
