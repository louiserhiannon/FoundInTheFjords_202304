using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerringSwim : MonoBehaviour
{
    private MoveToObject swim;
    public GameObject herringTargetPrefab;
    private GameObject herringTarget;

    private void Awake()
    {
        swim = GetComponent<MoveToObject>();
        swim.minDistance = 0.5f;
        swim.speed = Random.Range(SpawnEatableHerring.SH.minSpeed, SpawnEatableHerring.SH.maxSpeed);
        swim.rotationSpeed = Random.Range(SpawnEatableHerring.SH.minRotateSpeed, SpawnEatableHerring.SH.maxRotateSpeed);
        herringTarget = Instantiate(herringTargetPrefab, transform.position + 50 * Random.onUnitSphere, Quaternion.identity);
    }

    private void Start()
    {
        swim.targetTransform = herringTarget.transform;
        swim.distance = Vector3.Distance(transform.position, swim.targetTransform.position);
        StartCoroutine(SwimFromNet());
    }

    public IEnumerator SwimFromNet()
    {
        while (swim.distance > swim.minDistance)
        {
            swim.MoveToMinimumDistance();
            //followMom.Follow();

            yield return null;
        }
    }
}
