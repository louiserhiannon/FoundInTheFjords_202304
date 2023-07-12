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
    private float voiceover46Duration = 5.5f;
    public GameObject handModelLeft;
    public GameObject handModelRight;
    public LadderClimb ladderClimb;

    
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

        StartCoroutine(FlashHandsLeft());
        StartCoroutine(FlashHandsRight());

        yield return null;

    }

    public IEnumerator FlashHandsLeft()
    {
        while (ladderClimb.isFlashingLeft)
        {
            handModelLeft.SetActive(true);
            yield return new WaitForSeconds(1);
            handModelLeft.SetActive(false);
            yield return new WaitForSeconds(1);
            yield return null;
        }
        

    }

    public IEnumerator FlashHandsRight()
    {
        while (ladderClimb.isFlashingLeft)
        {
            handModelRight.SetActive(true);
            yield return new WaitForSeconds(1);
            handModelRight.SetActive(false);
            yield return new WaitForSeconds(1);
            yield return null;
        }


    }
}
