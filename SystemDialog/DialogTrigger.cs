using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject goDialog;
    public float dialogRadius = 1f;
    public bool dialogProcess; 
    private DialogNpc _dialogNpc;
    private DialogManager _dialogManager;
    
    readonly List<Dialog> _listNpcDialog = new List<Dialog>();

    private void Awake()
    {
        _dialogNpc = GetComponent<DialogNpc>();
        _dialogManager = GetComponent<DialogManager>();
        foreach (var npcDia in _dialogNpc.npc)
        {
            _listNpcDialog.Add(npcDia.GetComponent<Dialog>());
        }
    }
    private void Update()
    {
        if (dialogProcess == false)
        {
            if (Trigger() && Input.GetKeyDown(KeyCode.E))
            {
                foreach (var npcDio in _listNpcDialog)
                {
                    if (npcDio.gameObject == goDialog)
                    {
                        dialogProcess = true;
                        _dialogManager.StartDialog(npcDio);
                    }
                }
            }
        }
    }
    
    public bool Trigger()
    {
        float distanceNpc =  10f;
        foreach (var npc in _dialogNpc.npc)
        {
            float distance = Vector2.Distance(player.transform.position, npc.transform.position);
            if (distance <= dialogRadius)
            {
                if (distance < distanceNpc)
                {
                    distanceNpc = distance;
                    goDialog = npc;
                }
            }
        }
        if (goDialog != null) return true;
        return false;
    }
}
