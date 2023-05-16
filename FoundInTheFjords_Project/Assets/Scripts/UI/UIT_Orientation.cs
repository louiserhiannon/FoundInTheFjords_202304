using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIT_Orientation : MonoBehaviour
{
    public AudioSource claraAudioSource;
    public List<AudioClip> voiceoverClips; //voiceovers 4-6
    private float voiceover04Duration = 11.4f;
    private float voiceover05Duration = 7.1f;
    private float voiceover06Duration = 10.4f;
    public Canvas controllerInstructions;
    public GameObject leftFin;
    public GameObject rightFin;
    public GameObject leftController;
    public GameObject rightController;
    public CanvasGroup subtitlePanel;
    public List<CanvasGroup> subtitleSnippets;
    public ActionBasedSnapTurnProvider snapTurnProvider;
    public GameObject claraInteractionSignifierActual;
    public GameObject claraInteractionSignifierReflected;
    
    
    public void FinishMovementOrientation()
    {
        StartCoroutine(OrientationPart2());
    }

    public IEnumerator OrientationPart2()
    {
        //fade canvas panels
        foreach (CanvasGroup panel in controllerInstructions.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(0f, 1f);
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        yield return new WaitForSeconds(2f);
        //switch controller models back
        leftFin.SetActive(true);
        rightFin.SetActive(true);
        leftController.SetActive(false);
        rightController.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        //start voiceover 04 and subtitles
        claraAudioSource.PlayOneShot(voiceoverClips[0]);
        subtitlePanel.DOFade(1, 1);
        subtitleSnippets[0].DOFade(1, 1);
        //Switch on locomotion controls
        MovementControls.MC.ActivateMovementControls();
        snapTurnProvider.enabled = false;
        //wait for duration of clip
        yield return new WaitForSeconds(voiceover04Duration);
        subtitleSnippets[0].DOFade(0, 1);
        yield return new WaitForSeconds(1f);

        //start voiceover 05 and subtitles
        claraAudioSource.PlayOneShot(voiceoverClips[1]);
        subtitleSnippets[1].DOFade(1, 1);
        //wait for duration of clip
        yield return new WaitForSeconds(voiceover05Duration);
        subtitleSnippets[1].DOFade(0, 1);
        yield return new WaitForSeconds(1f);

        //start voiceover 06 and subtitles
        claraAudioSource.PlayOneShot(voiceoverClips[2]);
        subtitleSnippets[2].DOFade(1, 1);
        claraInteractionSignifierActual.SetActive(true);
        claraInteractionSignifierReflected.SetActive(true); 
        //wait for duration of clip
        yield return new WaitForSeconds(voiceover06Duration);
        subtitleSnippets[2].DOFade(0, 1);
        yield return new WaitForSeconds(1f);

        subtitlePanel.DOFade(0, 1);
        

    }
}
