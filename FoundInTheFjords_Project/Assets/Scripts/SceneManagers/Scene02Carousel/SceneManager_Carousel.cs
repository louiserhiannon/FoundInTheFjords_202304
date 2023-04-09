using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneManager_Carousel : SceneManager
{
    public CarouselSceneIntro carouselSceneIntro;
    public GameObject flockManager;
    
   

    protected override void Awake()
    {
        base.Awake();
        //Start orca mom swim animation
        orcaMomAnimator.SetTrigger("Trigger_Swim");

        //Disable flock manager
        flockManager.GetComponent<FlockManager>().enabled = false;

        //disable tailslap controller
        xRRig.GetComponent<TailslapController>().enabled = false;

        //Start Scene02IntroCoroutine
        StartCoroutine(carouselSceneIntro.Scene02Intro());

    }

    
}
