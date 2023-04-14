using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public LadderGrab lefthand;
    public LadderGrab righthand;
    public bool coroutineRunning = false;
    public Transform lefthandGrabPoint;
    public Transform righthandGrabPoint;
    public Transform xRRig;
    public Transform ladder;
    public Transform reverseParent;
    public float climbSpeed;
    
    
    // Update is called once per frame
    void Update()
    {
        if (lefthand.isGrabbed && righthand.isGrabbed)
        {
            if (!coroutineRunning)
            {
                Debug.Log("should be climbing ladder");
                StartCoroutine(ClimbLadder());
                coroutineRunning = true;
            }
        }
    }

    public IEnumerator ClimbLadder()
    {
        Vector3 targetPosition = reverseParent.position;
        Vector3 finalDirection = reverseParent.forward;

        while (xRRig.transform.position.y < targetPosition.y - 0.05 || xRRig.transform.position.y > targetPosition.y + 0.05)
        {
            xRRig.transform.position = Vector3.MoveTowards(xRRig.transform.position, targetPosition, climbSpeed * Time.deltaTime); 
            yield return null;
        }

        while (xRRig.transform.eulerAngles.y > reverseParent.eulerAngles.y + 5 || xRRig.transform.eulerAngles.y < reverseParent.eulerAngles.y - 5)
        {
            xRRig.transform.rotation = Quaternion.Slerp(xRRig.transform.rotation, Quaternion.LookRotation(finalDirection), climbSpeed * Time.deltaTime);
            yield return null;
        }
        

        yield return new WaitForSeconds(2f);

        while (righthandGrabPoint.localPosition.y < 0.15f)
        {
            righthandGrabPoint.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (xRRig.position.y < 1.4f)
        {
            xRRig.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (lefthandGrabPoint.localPosition.y < 0.30f)
        {
            lefthandGrabPoint.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (xRRig.position.y < 1.55f)
        {
            xRRig.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        while (righthandGrabPoint.localPosition.y < 0.45f)
        {
            righthandGrabPoint.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (xRRig.position.y < 1.70f)
        {
            xRRig.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (lefthandGrabPoint.localPosition.y < 0.60f)
        {
            lefthandGrabPoint.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (xRRig.position.y < 1.85f)
        {
            xRRig.Translate(climbSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        //Load next Scene

    }
}
