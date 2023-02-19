using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColor : MonoBehaviour
{
    private DialogTrigger _dialogTrigger;
    private DialogNpc _dialogNpc;
    readonly List<SpriteRenderer> _listRenderNpc = new List<SpriteRenderer>();
    
    private void Awake()
    {
        _dialogTrigger = GetComponent<DialogTrigger>();
        _dialogNpc = GetComponent<DialogNpc>();
        foreach (var npc in _dialogNpc.npc)
        {
            _listRenderNpc.Add(npc.GetComponent<SpriteRenderer>());
        }
        
    }

    private void Update()
    {
        Paint();
    }

    private bool _flag = false;
    void Paint()
    {
        if (_dialogTrigger.Trigger())
        {
            _flag = true;
            foreach (var npcRen in _listRenderNpc)
            {
                npcRen.color = npcRen.gameObject == _dialogTrigger.goDialog ? Color.green : Color.black;
            }
        }

        if (_flag)
        {
            if (Vector2.Distance(_dialogTrigger.player.transform.position, _dialogTrigger.goDialog.transform.position) >
                _dialogTrigger.dialogRadius)
            {
                foreach (var npcRen in _listRenderNpc)
                {
                    if (npcRen.gameObject == _dialogTrigger.goDialog)
                    {
                        npcRen.color = Color.black;
                        _flag = false;
                    }
                }
            }
        }
    }
}
