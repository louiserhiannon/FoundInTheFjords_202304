using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneManager : MonoBehaviour
{
    public List<Canvas> canvasList;
    public GameObject orcaMom;
    protected Animator orcaMomAnimator;
    public GameObject xRRig;


    protected virtual void Awake()
    {
        //Disable Panels
        for (int i = 0; i < canvasList.Count; i++)
        {
            foreach (CanvasGroup panel in canvasList[i].GetComponentsInChildren<CanvasGroup>())
            {
                panel.alpha = 0;
                panel.interactable = false;
                panel.blocksRaycasts = false;
            }
        }


        //Disable Move Controls
        xRRig.GetComponent<LocomotionController_General>().enabled = false;
        xRRig.GetComponentInChildren<ActionBasedSnapTurnProvider>().enabled = false;

        //Disable Eat Controller
        xRRig.GetComponent<EatingController>().enabled = false;
        
        //Get orca mom animator component
        orcaMomAnimator = orcaMom.GetComponent<Animator>();
        

        
    }


}
