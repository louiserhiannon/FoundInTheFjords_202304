using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveWaterSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip surfaceWaterClip;
    public DepthCalculator depthCalculator;
    public GameObject affectedParticleSystem;
    private bool _isAboveWater;
    public bool isAboveWater {
        get { return _isAboveWater ; }
        set {
            if ( _isAboveWater == false && value == true )
            {
                Debug.Log("Surfaced! isAboveWater changed from: " + _isAboveWater + "to: " + value);
                audioSource.Play();
                affectedParticleSystem.SetActive(false);
                
            }
            if ( _isAboveWater == true && value == false )
            {
                Debug.Log("Dove! isAboveWater changed from: " + _isAboveWater + "to: " + value);
                audioSource.Stop();
                affectedParticleSystem.SetActive(true);
            }
            _isAboveWater = value;
        }
    }
    // Am I going to hell for not using a co-routine? 

    void Start() {
        isAboveWater = false;
        audioSource.clip = surfaceWaterClip;
        audioSource.loop = true;
    }

    void Update() {
        if ( depthCalculator.headsetDepthCorrected > 0 ) {
            isAboveWater = true;
        }
        if ( depthCalculator.headsetDepthCorrected < 0 ) {
            isAboveWater = false;
        }
    }
    
}
