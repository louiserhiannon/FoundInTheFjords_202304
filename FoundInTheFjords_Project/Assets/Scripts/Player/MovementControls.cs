using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementControls : MonoBehaviour
{
    public static MovementControls MC;
    private GameObject xRRig;

    private void Awake()
    {
        xRRig = this.gameObject;
        MC = this;
    }
    public void ActivateMovementControls()
    {
        if (xRRig.GetComponent<LocomotionController_General>() != null)
        {
            xRRig.GetComponent<LocomotionController_General>().enabled = true;
        }
        else if (xRRig.GetComponent<LocomotionController_Orientation>() != null)
        {
            xRRig.GetComponent<LocomotionController_Orientation>().enabled = true;
        }

        if (xRRig.GetComponentInChildren<ActionBasedSnapTurnProvider>() != null)
        {
            xRRig.GetComponentInChildren<ActionBasedSnapTurnProvider>().enabled = true;
        }
    }

    public void DeactivateMovementControls()
    {
        if (xRRig.GetComponent<LocomotionController_General>() != null)
        {
            xRRig.GetComponent<LocomotionController_General>().enabled = false;
        }
        else if (xRRig.GetComponent<LocomotionController_Orientation>() != null)
        {
            xRRig.GetComponent<LocomotionController_Orientation>().enabled = false;
        }

        if (xRRig.GetComponentInChildren<ActionBasedSnapTurnProvider>() != null)
        {
            xRRig.GetComponentInChildren<ActionBasedSnapTurnProvider>().enabled = false;
        }
    }

    public void ActivateEatControls()
    {
        if (xRRig.GetComponent<EatingController>() != null)
        {
            xRRig.GetComponent<EatingController>().enabled = true;
            xRRig.GetComponent<EatingController>().targetActive = true;
        }
        
    }

    public void DeActivateEatControls()
    {
        if (xRRig.GetComponent<EatingController>() != null)
        {
            xRRig.GetComponent<EatingController>().enabled = false;
            xRRig.GetComponent<EatingController>().targetActive = false;
        }
    }
}
