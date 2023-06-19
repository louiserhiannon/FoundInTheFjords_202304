using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class UIT_SayGoodbye : UITransition
{
    public Canvas thisCanvas;
    public AudioClip voiceover46;
    public AudioClip voiceover47;
    private float voiceover46Duration = 8.3f;

    
    public override void UINext()
    {
        foreach (CanvasGroup panel in thisCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.interactable = false;
            panel.blocksRaycasts = false;
            panel.DOFade(0, 1);
        }

        StartCoroutine(SayGoodbye());

    }

    public IEnumerator SayGoodbye()
    {
        //play nora saying goodbye
        audioSource.PlayOneShot(voiceover46);
        yield return new WaitForSeconds(voiceover46Duration);

        //play mom saying goodbye
        audioSource.PlayOneShot(voiceover47);

        yield return null;

    }
}
