using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog;

    private DialogManager _dialogManager;

    private bool _playerInTheZone;
    // Start is called before the first frame update
    void Start()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            _playerInTheZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInTheZone && Input.GetKeyDown(KeyCode.Return))
        {
            _dialogManager.ShowDialog(dialog);
        }
    }
}
