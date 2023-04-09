using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBiteAnimation : MonoBehaviour
{
    private Animator orcaAnimator;

    void Start()
    {
        orcaAnimator= GetComponent<Animator>();
    }

    void Update()
    {
        if(orcaAnimator != null)
        {
            if(Random.Range(1,1000) < 5)
            {
                orcaAnimator.SetTrigger("Trigger_Bite");
            }
        }
    }
}
