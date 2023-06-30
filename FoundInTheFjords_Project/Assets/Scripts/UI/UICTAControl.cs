using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UICTAControl : MonoBehaviour
{
    public Canvas cTACanvas;
    public Canvas learnMoreCanvas;
    public CanvasGroup introPanel;
    public List<CanvasGroup> actionPanels;
    public AudioClip intro;
    private AudioSource uISource;

    void Start()
    {
        foreach (CanvasGroup panel in cTACanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0f;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        foreach (CanvasGroup panel in learnMoreCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0f;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        uISource = GetComponent<AudioSource>();

        StartCoroutine(UIAppear());
    }

    public IEnumerator UIAppear()
    {
        yield return new WaitForSeconds(3f);
        
        uISource.PlayOneShot(intro);
        
        yield return new WaitForSeconds(9f);

        introPanel.DOFade(1, 2);

        yield return new WaitForSeconds(5f);

        introPanel.DOFade(0, 2);

        for (int i = 0; i < actionPanels.Count; i++)
        {
            actionPanels[i].DOFade(1f, 2.0f);
            actionPanels[i].interactable = true;
            actionPanels[i].blocksRaycasts = true;
        }
    }
}
