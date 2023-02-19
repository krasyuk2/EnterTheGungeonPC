using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI textDialog;
    public GameObject panelPrefab;
    private Queue<string> sentences = new Queue<string>();
    private DialogTrigger _dialogTrigger;
    private DialogAnimation _dialogAnimation;
    private Cursor _cursor;
    private Player _player;
    

    private void Awake()
    {
        _dialogTrigger = GetComponent<DialogTrigger>();
        _dialogAnimation = GetComponent<DialogAnimation>();
        _cursor = GameObject.FindWithTag("Cursor").GetComponent<Cursor>();
        panelPrefab.SetActive(false);
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (_dialogTrigger.dialogProcess)
        {
            if(Input.GetKeyDown(KeyCode.E)) ContinueDialog();
        }
    }

    public void StartDialog(Dialog dialog)
    {
        panelPrefab.transform.position = new Vector2(dialog.gameObject.transform.position.x,
            dialog.gameObject.transform.position.y + 2f);
        panelPrefab.SetActive(true);
        _cursor.enabled = false;
        _player.enabled = false;
        
        _dialogAnimation.StartAnim();
         sentences.Clear();
         foreach (var sentence in dialog.sentences )
         {
             sentences.Enqueue(sentence);
         }
         ContinueDialog();
    }

    private void ContinueDialog()
    {
        if(sentences.Count == 0)
        {
            StartCoroutine(nameof(EndDialog)); 
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeText(sentence));
    }

    IEnumerator TypeText(string sentence)
    {
        textDialog.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            textDialog.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator EndDialog()
    {
        panelPrefab.SetActive(false);
        _cursor.enabled = true;
        _player.enabled = true;
        
        yield return new WaitForSeconds(0.01f);
        _dialogAnimation.CloseAnim();
        textDialog.text = "";
        _dialogTrigger.dialogProcess = false;
        
       
    }

  

}
