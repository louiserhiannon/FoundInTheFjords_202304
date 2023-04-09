using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine.XR.Interaction.Toolkit;


public class JellyInteractions : MonoBehaviour
{
    public Canvas jellyCanvas;
    public CanvasGroup firstPanel;
    private AudioSource jellyAudioSource;
    public AudioClip jellyClip;
    public CanvasGroup firstButton;
    public float clipDuration;
    public MeshRenderer interactionSignifier;
    private Color originalColour;
    public MovementControls moveControls;
    public MoveToObject moveToSnorkeler;
    public MoveToObject rotateToNora;
    public AudioSource zodiacDriverAudioSource;
    public AudioSource claraAudioSource;
    public AudioSource noraAudioSource;
    public AudioClip voiceover31;
    public AudioClip voiceover32;
    public AudioClip voiceover33;
    public AudioClip voiceover34;
    public AudioClip voiceover35;
    public AudioClip voiceover36;
    public AudioClip voiceover37;
    public AudioClip voiceover38;
    public AudioClip voiceover39;
    private float voiceover31Duration = 9.2f;
    private float voiceover32Duration = 9f;
    private float voiceover33Duration = 1.5f;
    private float voiceover34Duration = 7.7f;
    private float voiceover35Duration = 1.3f;
    private float voiceover36Duration = 10.4f;
    private float voiceover37Duration = 1.2f;
    private float voiceover38Duration = 8.6f;
    private float voiceover39Duration = 2.8f;
    public string coroutineName;
    public bool firstSelectionAudio = true;
    public bool firstSelectionUI = true;
    private bool coroutineStarted = false;




    private void Awake()
    {
        //jellyCanvas = FindObjectOfType<Canvas>();
        jellyAudioSource = GetComponent<AudioSource>();
        originalColour = interactionSignifier.material.color;
        DisablePanels();

        if (jellyClip == null)
        {
            clipDuration = 0f;
        }

    }

    
    private void DisablePanels()
    {
        foreach(CanvasGroup panel in jellyCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable= false;
            panel.blocksRaycasts= false;
        }
    }

    public void ChangeSignifierColour()
    {
        interactionSignifier.material.color = Color.green;
    }

    public void ResetSignifierColour()
    {
        interactionSignifier.material.color = originalColour;
    }


    public void PlayJellyAudio()
    {
        if (firstSelectionAudio)
        {
            if (jellyClip != null)
            {
                jellyAudioSource.PlayOneShot(jellyClip);
                firstSelectionAudio = false;
            }
            else
            {
                SelectAlternativeAction();
            }
        }
        

    }

    public void EnableJellyUI()
    {
        if (firstSelectionUI)
        {
            if (firstPanel != null)
            {
                firstPanel.DOFade(1f, 1.5f);
                firstPanel.interactable = true;
                firstPanel.blocksRaycasts = true;

                StartCoroutine(ShowButton());
                
                firstSelectionUI = false;
            }

        }
        else
        {
            SelectAlternativeAction();
        }
        
    }

    public void SelectAlternativeAction()
    {
        if(firstSelectionAudio || firstSelectionUI == false)
        {
            if(coroutineStarted == false)
            {
                StartCustomCoroutine(coroutineName);
                coroutineStarted = true;
            }
        }
    }

    public IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(clipDuration);
        firstButton.DOFade(1f, 1.5f);
        firstButton.interactable = true;
        firstButton.blocksRaycasts = true;
        Debug.Log("button should be visible");
    }

    public void StartCustomCoroutine(string name)
    {
        StartCoroutine(name);
    }

    public IEnumerator IntroduceSnorkelers()
    {
        //Play voiceover 31
        zodiacDriverAudioSource.PlayOneShot(voiceover31);
        yield return new WaitForSeconds(voiceover31Duration);
        //Play voiceover 32
        claraAudioSource.PlayOneShot(voiceover32);
        yield return new WaitForSeconds(voiceover32Duration);
        //Play voiceover 33
        zodiacDriverAudioSource.PlayOneShot(voiceover33);
        yield return new WaitForSeconds(voiceover33Duration);
        //Play snorkeler animation
        //Play voiceover 34
        claraAudioSource.PlayOneShot(voiceover34);
        yield return new WaitForSeconds(voiceover34Duration);
        //Play voiceover 35
        noraAudioSource.PlayOneShot(voiceover35);
        yield return new WaitForSeconds(voiceover35Duration);
        //Play voiceover 36
        claraAudioSource.PlayOneShot(voiceover36);
        yield return new WaitForSeconds(voiceover36Duration);
        //Play voiceover 37
        noraAudioSource.PlayOneShot(voiceover37);
        yield return new WaitForSeconds(voiceover37Duration);
        //Play voiceover 38
        claraAudioSource.PlayOneShot(voiceover38);
        yield return new WaitForSeconds(voiceover38Duration);
        //disable controls
        moveControls.DeactivateMovementControls();
        //move to face snorkeler
        moveToSnorkeler.distance = Vector3.Distance(moveToSnorkeler.targetTransform.position, moveToSnorkeler.transform.position);
        while (moveToSnorkeler.distance > moveToSnorkeler.minDistance)
        {
            moveToSnorkeler.MoveToMinimumDistance();
            yield return null;
        }

        //rotate to align to mom

        while (moveToSnorkeler.transform.eulerAngles.y < moveToSnorkeler.targetTransform.eulerAngles.y - 2 || moveToSnorkeler.transform.eulerAngles.y > moveToSnorkeler.targetTransform.eulerAngles.y + 2)
        {
            moveToSnorkeler.RotateToFace();
            rotateToNora.RotateToFace();
            yield return null;
            //xRRig.transform.rotation != moveToMom.targetTransform.rotation
        }

        //Play voiceover 39
        claraAudioSource.PlayOneShot(voiceover39);
        yield return new WaitForSeconds(voiceover39Duration);
        //Activate mirror actions on snorkeler

        coroutineStarted = false;

    }

}
