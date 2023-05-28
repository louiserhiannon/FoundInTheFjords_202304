using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02Coroutines : MonoBehaviour
{
    public AudioSource momAudioSource;
    public AudioClip voiceover18;
    private float voiceover18Duration = 6.5f;
    public void StartCustomCoroutine(string name)
    {
        StartCoroutine(name);
    }

    public IEnumerator ReadyToTravel()
    {
        //play voiceover 17
        momAudioSource.PlayOneShot(voiceover18);
        //wait a bit
        yield return new WaitForSeconds(voiceover18Duration);
        //ChangeScene
        ChangeScene.instance.SceneSwitch("Scene03-Locomotion");
        
        
    }
}
