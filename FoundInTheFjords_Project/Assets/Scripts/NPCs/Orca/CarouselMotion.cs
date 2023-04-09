using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class CarouselMotion : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;
    [SerializeField] private float rotateAngle;
    [SerializeField] private float targetOffset;
    [SerializeField] private float rotateDistance;
    [SerializeField] private float timeShift;
    [SerializeField] private float timeStretch;
    [SerializeField] private float initialOffset;
    [SerializeField] private bool coroutineRunning = false;
    private float minDistance;
    private float maxDistance;
    //[SerializeField] private float maxSlapDistance = 6.0f;
    private Animator tailslapAnimator;
    public bool isCarouselFeeding = true;
    


    void Start()
    {
        parentTransform = transform.parent;
        tailslapAnimator= GetComponent<Animator>();
        rotateAngle = Random.Range(CarouselManager.CM.minSpeed, CarouselManager.CM.maxSpeed);
        timeShift = Random.Range(CarouselManager.CM.minTimeShift, CarouselManager.CM.maxTimeShift);
        timeStretch = Random.Range(CarouselManager.CM.minTimeStretch, CarouselManager.CM.maxTimeStretch);
        initialOffset = Random.Range(-1f, 1f);
        minDistance = 5.0f;
        maxDistance = 7.0f;
        Vector3 direction = (transform.position - parentTransform.position).normalized;
        transform.Translate(initialOffset * direction);
        

    }

    void Update()
    {
        if (isCarouselFeeding)
        {
            //Calculate current distance from centre
            rotateDistance = Vector3.Distance(parentTransform.position, transform.position);

            //calculate speed
            if (CarouselManager.CM.controlSpeedWithDistance)
            {
                //CALCULATES SPEED BASED ON DISTANCE FROM AXIS
                SpeedFromDistance();
            }

            else
            {
                //CALCULATES RANDOM SPEED

                RandomSpeed();
            }

            //rotates around axis at given speed
            transform.RotateAround(parentTransform.position, parentTransform.up, -rotateAngle * Time.deltaTime);

            //calculates target distance from centre

            RadialOffset();


            //at randomized intervals, start coroutine that triggers tail slap and bite animation, returning to locomotion animation
            if (Random.Range(1, CarouselManager.CM.animationSensitivity) < 10)
            {
                if (rotateDistance <= CarouselManager.CM.maxSlapDistance)
                {
                    if (coroutineRunning == false)
                    {
                        StartCoroutine(TailslapAnimation());
                        coroutineRunning = true; //stops coroutine being interrupted
                    }

                }

            }
        }
        

    }

    private void RadialOffset()
    {
        float maxOffset = CarouselManager.CM.maxOffset;
        if (Random.Range(1, CarouselManager.CM.distanceSensitivity) < 10)
        {
            maxOffset = Random.Range(CarouselManager.CM.minOffset, CarouselManager.CM.maxOffset);
        }

        Vector3 direction = (transform.position - parentTransform.position).normalized;
        transform.Translate(maxOffset * (Mathf.Sin((Time.time + Time.deltaTime + timeShift) / timeStretch) - Mathf.Sin((Time.time + timeShift) / timeStretch)) * direction);
    }

    private void RandomSpeed()
    {
        if (rotateAngle <= CarouselManager.CM.maxSpeed && rotateAngle >= CarouselManager.CM.minSpeed)
        {
            rotateAngle += Random.Range(CarouselManager.CM.minAcceleration, CarouselManager.CM.maxAcceleration);
        }
        else if (rotateAngle > CarouselManager.CM.maxSpeed)
        {
            rotateAngle = CarouselManager.CM.maxSpeed;
        }
        else
        {
            rotateAngle = CarouselManager.CM.minSpeed;
        }
    }

    private void SpeedFromDistance()
    {
        

        if (rotateDistance < maxDistance && rotateDistance > minDistance)
        {
            rotateAngle = CarouselManager.CM.minSpeed + (maxDistance - rotateDistance) / (maxDistance - minDistance) * (CarouselManager.CM.maxSpeed - CarouselManager.CM.minSpeed);
        }
        else if (rotateDistance <= minDistance)
        {
            rotateAngle = CarouselManager.CM.maxSpeed;
        }
        else
        {
            rotateAngle = CarouselManager.CM.minSpeed;
        }
    }

    IEnumerator TailslapAnimation()
    {

        if (tailslapAnimator != null)
        {
            tailslapAnimator.SetTrigger("Trigger_TailSlap");

            yield return new WaitForSeconds(1.5f);

            //Spawn stunned herring
            int spawnedHerringCount = Random.Range(CarouselManager.CM.minSpawnedHerring, CarouselManager.CM.maxSpawnedHerring);

            for (int i = 0; i < spawnedHerringCount; i++)
            {
                Vector3 pos = transform.position + 0.3f * (parentTransform.position - transform.position);
                pos += new Vector3(Random.Range(-CarouselManager.CM.spawnOffsetX, CarouselManager.CM.spawnOffsetX), Random.Range(-CarouselManager.CM.spawnOffsetY, CarouselManager.CM.spawnOffsetY), Random.Range(-CarouselManager.CM.spawnOffsetZ, CarouselManager.CM.spawnOffsetZ));
                Instantiate(CarouselManager.CM.stunnedHerringPrefab, pos, Random.rotation);
            }

            yield return new WaitForSeconds(1.5f);

            tailslapAnimator.SetTrigger("Trigger_SlapToSwim");

            yield return new WaitForSeconds(1.0f);

            tailslapAnimator.SetTrigger("Trigger_Bite");

            yield return new WaitForSeconds(0.5f);

            tailslapAnimator.SetTrigger("Trigger_BiteToSwim");

            yield return new WaitForSeconds(1.0f);

            tailslapAnimator.SetTrigger("Trigger_Bite");

            yield return new WaitForSeconds(0.5f);

            tailslapAnimator.SetTrigger("Trigger_BiteToSwim");

        }

         coroutineRunning = false; //allows corouting to be started again

    }
}
