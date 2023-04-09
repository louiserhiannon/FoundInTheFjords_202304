using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumpbackTestController : MonoBehaviour
{
    public HumpbackSwimAnimation animationController;
    public MoveToObject humpbackSwimToBaitball;
    //public MoveToObject orcaFlee;
    public Transform humpbackTurnTarget;
    public Transform humpbackEatTarget;
    public Transform humpbackFleeTarget;
    public Transform orcaFleeTarget;
    public List<Transform> orcas;
    public List<MoveToObject> orcaFlees;
    public TailSlapTutorial tailslapTutorial;

    // Start is called before the first frame update
    private void Awake()
    {
        humpbackSwimToBaitball.targetTransform = humpbackTurnTarget;
        
    }

    //void Start()
    //{
    //    CarouselManager.CM.SpawnCarouselOrca();
    //    StartCoroutine(GoHumpback());
    //}

    public IEnumerator GoHumpback()
    {
        //start humpback animation
        humpbackSwimToBaitball.targetTransform = humpbackTurnTarget;
        animationController.StartSwim();
        humpbackSwimToBaitball.distance = Vector3.Distance(humpbackSwimToBaitball.targetTransform.position, humpbackSwimToBaitball.transform.position);
        while (humpbackSwimToBaitball.distance > humpbackSwimToBaitball.viewDistance)
        {
            humpbackSwimToBaitball.MoveToMinimumDistance();
            yield return null;
        }

        //orca swim off
        StartCoroutine(OrcaSwimAway());
        Debug.Log("orca swim away");

        MovementControls.MC.ActivateMovementControls();

        //humpback continues
        while (humpbackSwimToBaitball.distance > humpbackSwimToBaitball.minDistance)
        {
            humpbackSwimToBaitball.MoveToMinimumDistance();
            yield return null;
        }

        //humpback continues to surface
        StartCoroutine(Gulp());

        humpbackSwimToBaitball.targetTransform = humpbackEatTarget;
        humpbackSwimToBaitball.distance = Vector3.Distance(humpbackSwimToBaitball.targetTransform.position, humpbackSwimToBaitball.transform.position);
        Debug.Log(humpbackSwimToBaitball.distance);

        while (humpbackSwimToBaitball.distance > humpbackSwimToBaitball.minDistance)
        {
            humpbackSwimToBaitball.MoveToMinimumDistance();
            yield return null;
        }

        //Destroy herring
        for (int i = FlockManager.FM.numFlockers - 1; i > -1 ; i--)
        {
            if(i%6 == 0)
            {
                
            }
            else
            {
                Destroy(FlockManager.FM.allFlockers[i]);
                FlockManager.FM.allFlockers.RemoveAt(i);
            }
        }

        tailslapTutorial.momAudioSource.PlayOneShot(tailslapTutorial.voiceover17);

        humpbackSwimToBaitball.targetTransform = humpbackFleeTarget;
        humpbackSwimToBaitball.distance = Vector3.Distance(humpbackSwimToBaitball.targetTransform.position, humpbackSwimToBaitball.transform.position);
        animationController.StartSwim();
        //tailslapTutorial.ActivateMovementControls();

        while (humpbackSwimToBaitball.distance > humpbackSwimToBaitball.minDistance)
        {
            humpbackSwimToBaitball.MoveToMinimumDistance();
            yield return null;
        }

    }

    public IEnumerator Gulp()
    {
        yield return new WaitForSeconds(1.9f);
        animationController.StopSwim();
        yield return new WaitForSeconds(0.1f);
        animationController.StartGulp();

    }

    public IEnumerator OrcaSwimAway()
    {
        
        for (int i = 0; i < CarouselManager.CM.allAxes.Length; i++)
        {
            //stop axis rotation
            CarouselManager.CM.allAxes[i].GetComponent<RotateCarouselAxis>().isRotating = false;
            //remove model from parent transform
            var model = CarouselManager.CM.allAxes[i].transform.Find("Orca_Shoaling_Animated");
            model.SetParent(null, true);
            //add to new list
            orcas.Add(model);
            

        }
        

        for(int i = 0; i < orcas.Count; i++)
        {
            //stop carousel rotation
            orcas[i].GetComponent<CarouselMotion>().isCarouselFeeding = false;
        }



        for (int i = 0; i < orcas.Count; i++)
        {
            var flee = orcas[i].GetComponent<MoveToObject>();
            orcaFlees.Add(flee);

            //set target transform
            orcaFlees[i].targetTransform = orcaFleeTarget;

            //calculate distance
            orcaFlees[i].distance = Vector3.Distance(orcaFlees[i].targetTransform.position, orcaFlees[i].transform.position);
        }


        while (orcaFlees[0].distance > orcaFlees[0].minDistance)
        {
            for (int i = 0; i < orcaFlees.Count; i++)
            {
                orcaFlees[i].MoveToMinimumDistance();
            }
            yield return null;
        }


    }
}
