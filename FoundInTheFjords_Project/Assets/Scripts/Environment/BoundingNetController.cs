using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoundingNetController : MonoBehaviour
{
    public bool canMove = true;
    public ActionBasedSnapTurnProvider snapTurnProvider;
    private void Awake()
    {
        snapTurnProvider.enableTurnLeftRight = true;
        this.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(true);
            canMove = false;
            Debug.Log("canMove = false");
            if (snapTurnProvider != null)
            {
                snapTurnProvider.enableTurnLeftRight = false;
            }

        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            canMove = true;
            Debug.Log("canMove = true");
            if (snapTurnProvider != null)
            {
                snapTurnProvider.enableTurnLeftRight = true;
            }
        }
        
    }
}
