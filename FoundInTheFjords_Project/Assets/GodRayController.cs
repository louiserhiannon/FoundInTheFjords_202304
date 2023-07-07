using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRayController : MonoBehaviour
{
    public float godRayY;
    public Transform followTarget;

    void Update() {
        Vector3 target = new Vector3(followTarget.position.x, godRayY, followTarget.position.z + 5);
        transform.position = target;
    }
}
