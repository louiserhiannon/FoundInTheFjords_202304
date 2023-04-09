using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class IdentitySwap : MonoBehaviour
{
    public ParticleSystem swirl;
    public ParticleSystem scales;
    
    public AudioClip voiceover41;
    public AudioClip voiceover42;
    public AudioClip voiceover43;
    public AudioClip swirlMusic;
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public GameObject leftSnorkelerPrefab;
    public GameObject rightSnorkelerPrefab;
    public GameObject leftFinPrefab;
    public GameObject rightFinPrefab;
    public GameObject snorkeler;
    public GameObject noraPrefab;
    public GameObject cameraFilter;
    public Canvas areYouReady;

    private AudioSource audioSource;
    private float voiceover41Duration = 2f;
    private float voiceover42Duration = 25.5f;
    private float voiceover43Duration = 15.8f;
    private GameObject nora;
    private Material cameraFilterMaterial;
    private Color cameraFilterColour;
    private float cameraFilterAlpha;
    private void Start()
    {
        cameraFilterMaterial = cameraFilter.GetComponent<MeshRenderer>().material;
        cameraFilterColour = cameraFilterMaterial.color;
        cameraFilterAlpha = cameraFilterColour.a;
        audioSource= GetComponent<AudioSource>();
    }

    public IEnumerator SwitchBodies()
    {
        //instantiate orca model and hide
        nora = Instantiate(noraPrefab, snorkeler.transform);
        nora.SetActive(false);
        //Start swirl animation
        swirl.Play();
        //Start swirl music
        audioSource.PlayOneShot(swirlMusic, 0.5f);
        yield return new WaitForSeconds(1.5f);
        //start herring scales animation
        scales.Play();
        //Wait a bit
        yield return new WaitForSeconds(3.0f);
        //voiceover 41
        audioSource.PlayOneShot(voiceover41);
        yield return new WaitForSeconds(voiceover41Duration);
        
        //Fade lights down
        cameraFilterMaterial.DOColor(Color.black, 1);
        cameraFilterMaterial.DOFade(1, 1);
        yield return new WaitForSeconds(1.2f);
        //Disable snorkeler model
        snorkeler.SetActive(false);
        //Enable orca model
        nora.SetActive(true);
        //switch controller prefabs
        leftController.modelPrefab = leftSnorkelerPrefab.transform;
        rightController.modelPrefab = rightSnorkelerPrefab.transform;
        //fade lights up
        cameraFilterMaterial.DOColor(cameraFilterColour, 1);
        cameraFilterMaterial.DOFade(cameraFilterAlpha, 1);
        yield return new WaitForSeconds(2.2f);
        //Switch a few times
        //Fade lights down
        cameraFilterMaterial.DOColor(Color.black, 1);
        cameraFilterMaterial.DOFade(1, 1);
        yield return new WaitForSeconds(1.2f);
        //Disable snorkeler model
        snorkeler.SetActive(true);
        //Enable orca model
        nora.SetActive(false);
        //switch controller prefabs
        leftController.modelPrefab = leftSnorkelerPrefab.transform;
        rightController.modelPrefab = rightSnorkelerPrefab.transform;
        //fade lights up
        cameraFilterMaterial.DOColor(cameraFilterColour, 1);
        cameraFilterMaterial.DOFade(cameraFilterAlpha, 1);
        yield return new WaitForSeconds(2.2f);

        //Fade lights down
        cameraFilterMaterial.DOColor(Color.black, 1);
        cameraFilterMaterial.DOFade(1, 1);
        yield return new WaitForSeconds(1.2f);
        //Disable snorkeler model
        snorkeler.SetActive(false);
        //Enable orca model
        nora.SetActive(true);
        //switch controller prefabs
        leftController.modelPrefab = leftSnorkelerPrefab.transform;
        rightController.modelPrefab = rightSnorkelerPrefab.transform;
        //fade lights up
        cameraFilterMaterial.DOColor(cameraFilterColour, 1);
        cameraFilterMaterial.DOFade(cameraFilterAlpha, 1);
        yield return new WaitForSeconds(2.2f);

        //Fade lights down
        cameraFilterMaterial.DOColor(Color.black, 1);
        cameraFilterMaterial.DOFade(1, 1);
        yield return new WaitForSeconds(1.2f);
        //Disable snorkeler model
        snorkeler.SetActive(true);
        //Enable orca model
        nora.SetActive(false);
        //switch controller prefabs
        leftController.modelPrefab = leftSnorkelerPrefab.transform;
        rightController.modelPrefab = rightSnorkelerPrefab.transform;
        //fade lights up
        cameraFilterMaterial.DOColor(cameraFilterColour, 1);
        cameraFilterMaterial.DOFade(cameraFilterAlpha, 1);
        yield return new WaitForSeconds(2.2f);

        //Fade lights down
        cameraFilterMaterial.DOColor(Color.black, 1);
        cameraFilterMaterial.DOFade(1, 1);
        yield return new WaitForSeconds(1.2f);
        //Disable snorkeler model
        snorkeler.SetActive(false);
        //Enable orca model
        nora.SetActive(true);
        //switch controller prefabs
        leftController.modelPrefab = leftSnorkelerPrefab.transform;
        rightController.modelPrefab = rightSnorkelerPrefab.transform;
        //fade lights up
        cameraFilterMaterial.DOColor(cameraFilterColour, 1);
        cameraFilterMaterial.DOFade(cameraFilterAlpha, 1);
        yield return new WaitForSeconds(2.2f);


        //voiceover 42
        audioSource.PlayOneShot(voiceover42);
        yield return new WaitForSeconds(voiceover42Duration);

        //voiceover 43
        audioSource.PlayOneShot(voiceover43);
        yield return new WaitForSeconds(voiceover43Duration);
        
        //are you ready? panel
        foreach(CanvasGroup panel in GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(1, 1);
            panel.blocksRaycasts = true;
            panel.interactable = true;
        }


    }
}
