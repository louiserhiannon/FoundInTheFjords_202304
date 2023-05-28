using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private bool isPlaying = false;
    private ParticleSystem bubbles;
    void Start()
    {
        bubbles = GetComponentInChildren<ParticleSystem>();
        StartCoroutine(PlayBubbles());
    }

    private void Update()
    {
        if(!isPlaying)
        {
            StartCoroutine(PlayBubbles());
        }
    }

    private IEnumerator PlayBubbles()
    {

        isPlaying = true;
        yield return new WaitForSeconds(Random.Range(7f, 15f));
        bubbles.Play();
        yield return new WaitForSeconds(Random.Range(2f, 4f));
        bubbles.Stop();
        isPlaying = false;
    }
}
