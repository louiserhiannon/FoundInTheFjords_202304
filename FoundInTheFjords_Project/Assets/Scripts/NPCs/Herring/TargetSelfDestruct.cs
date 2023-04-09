using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelfDestruct : MonoBehaviour
{

    private float lifetime = 0f;
    
    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= EatingController.EC.herringLifetime)
        {
            Destroy(gameObject);
        }
    }
}
