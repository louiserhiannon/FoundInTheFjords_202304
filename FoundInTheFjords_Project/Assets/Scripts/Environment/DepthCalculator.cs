using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCalculator : MonoBehaviour
{
    public static DepthCalculator dc;
    public Transform headset; //Transform component of maincamera Game object
    public float headsetDepth; //y-coordinate (height) of camera in world space
    public float headsetDepthCorrected; // corrected depth that takes into account that ocean surface is at y = 2 (due to sky box)

    // Start is called before the first frame update
    void Awake()
    {
        dc = this;
    }

    // Update is called once per frame
    void Update()
    {
        headsetDepth = headset.position.y;
        headsetDepthCorrected = headsetDepth - 2f;
    }
}
