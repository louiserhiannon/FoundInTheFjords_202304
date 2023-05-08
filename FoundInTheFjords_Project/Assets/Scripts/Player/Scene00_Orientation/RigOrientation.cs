using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigOrientation : MonoBehaviour
{
    //public Transform headset; //Transform component of maincamera Game object
    //[SerializeField]
    //protected float headsetDepth; //y-coordinate (height) of camera in world space
    //[SerializeField]
    //protected float headsetDepthCorrected;// corrected depth that takes into account that ocean surface is at y = 2 (due to sky box)
    private float rotationAbove = 180f;
    private float rotationBelow = 90f;
    
    



    // Update is called once per frame
    void Update()
    {
        //headsetDepth = headset.position.y;
        //headsetDepthCorrected = headsetDepth - 2f;

        //when the camera is above the water surface
        if (DepthCalculator.dc.headsetDepthCorrected >= 0)
        {
            transform.localEulerAngles = new Vector3(rotationAbove, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        else
        {
            transform.localEulerAngles = new Vector3(rotationBelow, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
