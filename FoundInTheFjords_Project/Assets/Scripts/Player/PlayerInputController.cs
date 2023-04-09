using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    //Script to convert controller inputs into mirror animations on the orca reflection during orientation   
    public InputActionReference biteAction = null;
    public InputActionReference swimAction = null;
    public InputActionReference tailSlapAction = null;
    protected float slapCharge = 0f;
    protected float tailChargeRequired = 100f;
    public bool tailCharged = false;
    public float tailChargeDisplayed;
    public TMP_Text tailChargeText;
    public TMP_Text chargedText;
    [SerializeField] protected float yvalue;
    [SerializeField] protected float xvalue;
    [SerializeField] protected float gripValue;



    protected virtual void Awake()
    {
        if(chargedText!= null)
        {
            chargedText.text = "Ready";
        }

        if (tailChargeText != null)
        {
            tailChargeText.text = "Ready";
        }


    }

    protected void OnEnable()
    {
        biteAction.action.started += Bite;
    }

    protected void OnDisable()
    {
        biteAction.action.started -= Bite;
    }

    protected virtual void Update()
    {
        Vector2 thumbstickPosition = swimAction.action.ReadValue<Vector2>();
        yvalue = thumbstickPosition.y;
        xvalue = thumbstickPosition.x;
        float gripPosition = tailSlapAction.action.ReadValue<float>();
        gripValue = gripPosition;


    }

    public virtual void Bite(InputAction.CallbackContext context)
    {
        
    }

    public virtual void TailSlap(float value)
    {
        slapCharge += value;
        tailChargeDisplayed = Mathf.Clamp(slapCharge, 0f, tailChargeRequired);
        tailChargeText.text = tailChargeDisplayed.ToString();
        if (slapCharge > tailChargeRequired) //there must be a better way of doing this that doesn't involve using the same if statement twice...
        {
            tailCharged = true;
            chargedText.text = "Charged";
        }


    }

    public virtual void Swim(float xValue, float yValue)
    {
        
    }

}
