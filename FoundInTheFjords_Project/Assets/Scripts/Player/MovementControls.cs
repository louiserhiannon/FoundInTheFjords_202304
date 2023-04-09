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
        xRRig.GetComponent<LocomotionController_General>().enabled = true;
        xRRig.GetComponentInChildren<ActionBasedSnapTurnProvider>().enabled = true;
    }

    public void DeactivateMovementControls()
    {
        xRRig.GetComponent<LocomotionController_General>().enabled = false;
        xRRig.GetComponentInChildren<ActionBasedSnapTurnProvider>().enabled = false;
    }

    public void ActivateEatControls()
    {
        xRRig.GetComponent<EatingController>().enabled = true;
        xRRig.GetComponent<EatingController>().targetActive = true;
    }

    public void DeActivateEatControls()
    {
        xRRig.GetComponent<EatingController>().enabled = false;
        xRRig.GetComponent<EatingController>().targetActive = false;
    }
}
