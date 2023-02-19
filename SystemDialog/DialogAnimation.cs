using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnimation : MonoBehaviour
{ 
    public Animator[] animatorPanel;

    public void StartAnim()
    {
        foreach (var anim in animatorPanel)
        {
            anim.SetBool(Animator.StringToHash("DialogStart"), true);
        }
    }

    public void CloseAnim()
    {
        foreach (var anim in animatorPanel)
        {
            anim.SetBool(Animator.StringToHash("DialogStart"), false);
        }
    }

    
}
