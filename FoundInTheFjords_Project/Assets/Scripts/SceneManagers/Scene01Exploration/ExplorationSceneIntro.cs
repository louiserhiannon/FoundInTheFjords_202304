using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExplorationSceneIntro : MonoBehaviour
{
    public AudioSource headsetAudioSource;
    public AudioClip voiceover00;
    private float voiceover00Duration = 10f;
    public CanvasGroup subtitleSnippet0;
    public CanvasGroup controllerInstructions;
    public CanvasGroup controllerInstructionsButton;
    public GameObject leftFin;
    public GameObject rightFin;
    public GameObject leftController;
    public GameObject rightController;
    public CanvasGroup subtitlePanel;
    public IEnumerator Scene01Intro()
    {
        yield return new WaitForSeconds(2f);
        //play voiceover 0 and show subtitle 0
        headsetAudioSource.PlayOneShot(voiceover00);
        subtitlePanel.DOFade(1, 1);
        subtitleSnippet0.DOFade(1, 1);
        //wait for duration of clip
        yield return new WaitForSeconds(voiceover00Duration);
        //fade subtitle snippet and panel
        subtitleSnippet0.DOFade(0, 1);
        subtitlePanel.DOFade(0, 1);
        yield return new WaitForSeconds(1f);
        //show instructional panel and switch out fins for controllers
        controllerInstructions.DOFade(1.0f, 1.5f);
        controllerInstructions.interactable = true;
        controllerInstructions.blocksRaycasts = true;
        controllerInstructionsButton.DOFade(1.0f, 1.5f);

        leftFin.SetActive(false);
        rightFin.SetActive(false);
        leftController.SetActive(true);
        rightController.SetActive(true);


        //pause for learning and practice
        yield return new WaitForSeconds(10f);

        //Activate button
        
        controllerInstructionsButton.interactable = true;
        controllerInstructionsButton.blocksRaycasts = true;

    }
}
