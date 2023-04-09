using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICTAControl : MonoBehaviour
{
    public Canvas cTACanvas;

    void Start()
    {
        foreach (CanvasGroup panel in cTACanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0f;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }

        StartCoroutine(UIAppear());
    }

    public IEnumerator UIAppear()
    {
        yield return new WaitForSeconds(10f);

        foreach (CanvasGroup panel in cTACanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(0.9f, 2.0f); 
            panel.interactable = true;
            panel.blocksRaycasts = true;
        }
    }
}
