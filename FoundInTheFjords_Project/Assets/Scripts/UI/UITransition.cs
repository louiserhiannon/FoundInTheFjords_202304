using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using Unity.VisualScripting;
using TMPro;

public class UITransition : MonoBehaviour
{
    public Canvas infoUI;
    public CanvasGroup nextPanel;
    //public CanvasGroup nextPanelButton;
    public AudioSource audioSource;
    public CanvasGroup keyboard;
    private string storedTemplateID = null;
    
    
    
    //public AudioClip clip;
    //public float audioClipDuration;
    
    

    public virtual void UINext()
    {
        
        
        if (nextPanel != null)
        {
            //if(clip == null)
            //{
            //    audioClipDuration = 0;
            //}
            StartCoroutine(SwitchPanel()); 
            
        }

    }

    public virtual void UINextNoFade()
    {


        if (nextPanel != null)
        {
            nextPanel.DOFade(1, 1.5f);
            nextPanel.interactable = true;
            nextPanel.blocksRaycasts = true;

        }

    }

    public void UIFade()
    {

        
            foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
            {
                panel.DOFade(0f, 1.0f);
                panel.interactable = false;
                panel.blocksRaycasts = false;
            }
        
    }

   

   

    protected IEnumerator SwitchPanel()
    {
        foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(0f, 1.0f);
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        yield return new WaitForSeconds(1.1f);

        nextPanel.DOFade(1f, 1.5f);
        nextPanel.interactable = true;
        nextPanel.blocksRaycasts = true;

        //yield return new WaitForSeconds(0.5f);
        //if(clip != null)
        //{
        //    audioSource.PlayOneShot(clip);
        //    Debug.Log("clip should be playing");
        //}

        //yield return new WaitForSeconds(audioClipDuration);

        //nextPanelButton.DOFade(1f, 1.5f);
        //nextPanelButton.interactable = true;
        //nextPanelButton.blocksRaycasts = true;
        //SEE IF YOU CAN DELAY THE APPEARANCE OF BUTTON - Perhaps put on different panel?
        //add something in code to make it look like I'm doing something
    }

    public void ShowKeyboard()
    {
        keyboard.DOFade(1f, 1f);
        keyboard.interactable = true;
        keyboard.blocksRaycasts = true;
    }

    public void HideKeyboard()
    {
        keyboard.DOFade(0f, 1f);
        keyboard.interactable = false;
        keyboard.blocksRaycasts = false;
    }


    public void SetTemplateID(string templateID)
    {
        storedTemplateID = templateID;
    }

    public void PostData(TMP_InputField inputField)
    {
        if(SendEmail.SE != null)
        {
            string emailAddress = inputField.text;
            StartCoroutine(SendEmail.SE.PostData_Coroutine(emailAddress, storedTemplateID));
        }
        
    }

    

}
