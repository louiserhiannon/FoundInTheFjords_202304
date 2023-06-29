using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroLevelController : MonoBehaviour
{
    //controls the zoom animation and voiceover for the intro scene
    public Transform xRRig;
    public GameObject earth;
    public Animator xrRigZoomAnimator;
    public Animator pinAnimator;
    public float cameraZoom01Duration = 17f;
    public float cameraZoom02Duration;
    public float cameraZoom03Duration;
    public AudioSource audioSource;
    public AudioClip introVoiceover01;
    public AudioClip introVoiceover02;
    public AudioClip introVoiceover03;
    public AudioClip introVoiceover04;
    public AudioClip splash;
    public float clipDuration01;
    public float clipDuration02;
    public float clipDuration03;
    public float clipDuration04;
    public GameObject orca;
    public GameObject earthPlain;
    public GameObject earthOrcaDistribution;
    public GameObject locationPin;
    public GameObject underwaterPanorama;
    public CanvasGroup fishingBoat;
    public CanvasGroup containerBoat;
    public CanvasGroup tourists;
    //public Material underwaterSkybox;
    



    void Awake()
    {
        //set initial position of Rig
        xRRig.position = new Vector3(-35, 255, -875.5f);
        xRRig.eulerAngles = new Vector3(15.73f, 2.293f, 0f);
        //Start zoom coroutine
        StartCoroutine(IntroLevel());
        
        //initialize game objects and materials
        orca.SetActive(false);
        earthPlain.SetActive(true);
        earthOrcaDistribution.SetActive(false);
        locationPin.SetActive(false);
        underwaterPanorama.SetActive(false);
        fishingBoat.alpha = 0;
        containerBoat.alpha = 0;
        tourists.alpha = 0;
    }

    protected IEnumerator IntroLevel()
    {
        //Start Zoom01 animation
        if(xrRigZoomAnimator != null)
        {
            xrRigZoomAnimator.SetTrigger("CameraZoom01");
        }
        //Wait for seconds (length of zoom 1 animation (15 s)
        yield return new WaitForSeconds(cameraZoom01Duration);

        //play intro voiceover 1
        audioSource.PlayOneShot(introVoiceover01);
        //wait for length of voice over 01
        yield return new WaitForSeconds(clipDuration01);

        //play voiceover 2a
        audioSource.PlayOneShot(introVoiceover02);
        //wait fraction of a second
        yield return new WaitForSeconds(3.0f);
        //activate orca model (with locomotion animation)
        orca.SetActive(true);

        //Wait some seconds
        yield return new WaitForSeconds(clipDuration02);
        //play voiceover 2b
        audioSource.PlayOneShot(introVoiceover03);
        StartCoroutine(ShowPictures());
        //Deactivate plain model, activate orca distribution model
        earthPlain.SetActive(false);
        earthOrcaDistribution.SetActive(true);
        //wait until end of voiceover 2 b
        yield return new WaitForSeconds(clipDuration03);

        //Deactivate orca distribution model and reactivate plain model
        earthPlain.SetActive(true);
        earthOrcaDistribution.SetActive(false);
        //Deactivate orca model
        orca.SetActive(false);

        //Wait some seconds
        yield return new WaitForSeconds(2f);
        //play voiceover 3
        audioSource.PlayOneShot(introVoiceover04);
        //Start Zoom02 animation
        if (xrRigZoomAnimator != null)
        {
            xrRigZoomAnimator.SetTrigger("CameraZoom02");
        }
        //wait 0.5 s
        yield return new WaitForSeconds(0.5f);
        //Activate pin
        locationPin.SetActive(true);
        while(earth.transform.eulerAngles.y > 90)
        {
            yield return null;
        }
        earth.GetComponent<EarthRotation>().isRotating = false;
        //Wait until almost the end of the clip
        yield return new WaitForSeconds(22.5f);
        //Start Zoom03 animation
        if (xrRigZoomAnimator != null)
        {
            xrRigZoomAnimator.SetTrigger("CameraZoom03");
        }
        if (pinAnimator!= null)
        {
            pinAnimator.SetTrigger("Trigger_ScaleDown");
        }
        //wait for end of animation
        yield return new WaitForSeconds(cameraZoom03Duration-0.5f);
        //change skybox
        //RenderSettings.skybox = underwaterSkybox;
        underwaterPanorama.SetActive(true);
        earth.SetActive(false);
        audioSource.PlayOneShot(splash);
        yield return new WaitForSeconds(5.0f);
        //Load next scene
        ChangeScene.instance.SceneSwitch("Scene00-Orientation");

    }

    private IEnumerator ShowPictures()
    {
        yield return new WaitForSeconds(17.5f);
        fishingBoat.DOFade(1,0.5f);
        yield return new WaitForSeconds(0.5f);
        containerBoat.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        tourists.DOFade(1, 0.5f);
        yield return new WaitForSeconds(6.5f);
        fishingBoat.DOFade(0, 0.5f);
        containerBoat.DOFade(0, 0.5f);
        tourists.DOFade(0, 0.5f);

    }
}
