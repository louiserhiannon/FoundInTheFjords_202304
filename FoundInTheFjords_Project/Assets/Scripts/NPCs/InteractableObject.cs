using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private MeshRenderer interactionSignifier;
    private Color originalColour;
    public Level00Coroutines level00;
    public Level01Coroutines level01;
    public Level02Coroutines level02;
    public CanvasGroup panel;

    private void Awake()
    {
        interactionSignifier = GetComponent<MeshRenderer>();
        originalColour = interactionSignifier.material.color;
    }


    public void ChangeSignifierColour()
    {
        interactionSignifier.material.color = Color.green;
    }

    public void ResetSignifierColour()
    {
        interactionSignifier.material.color = originalColour;
    }

    public void PerformAction00(string coroutineName)
    {
        if(level00 != null)
        {
            level00.StartCustomCoroutine(coroutineName);
            this.gameObject.SetActive(false);
        }
        
    }

    public void PerformAction01(string coroutineName)
    {
        if(level01 != null)
        {
            level01.StartCustomCoroutine(coroutineName);
            this.gameObject.SetActive(false);
        }
        
    }

    public void PerformAction02(string coroutineName)
    {
        if (level02 != null)
        {
            level02.StartCustomCoroutine(coroutineName);
            this.gameObject.SetActive(false);
        }

    }

    public void ShowPanel()
    {
        if(panel != null)
        {
            panel.DOFade(1, 1);
            panel.blocksRaycasts = true;   
            panel.interactable = true;
            this.gameObject.SetActive(false);
        }
    }


}

