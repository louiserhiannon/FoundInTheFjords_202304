using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerringSwim : MonoBehaviour
{
    private MoveToObject swim;
    public GameObject herringTargetPrefab;
    public Vector3 herringStorageArea;
    private GameObject herringTarget;

    private void Awake()
    {
        swim = GetComponent<MoveToObject>();
        swim.minDistance = 0.5f;
        swim.speed = Random.Range(SpawnEatableHerring.SH.minSpeed, SpawnEatableHerring.SH.maxSpeed);
        swim.rotationSpeed = Random.Range(SpawnEatableHerring.SH.minRotateSpeed, SpawnEatableHerring.SH.maxRotateSpeed);
        Vector3 dir = new Vector3(Random.Range(1f,-1f), Random.Range(-1f,0f), Random.Range(-1f,0f)).normalized;
        Vector3 pos = transform.position + dir * 25;
        herringTarget = Instantiate(herringTargetPrefab, pos, Quaternion.identity);
        swim.targetTransform = herringTarget.transform;
        //herringTarget.SetActive(false);
        herringStorageArea = transform.position;
        //this.gameObject.SetActive(false);
    }

    
    private void OnEnable()
    {
        swim.targetTransform = herringTarget.transform;
        swim.distance = Vector3.Distance(transform.position, swim.targetTransform.position);
        //herringTarget.SetActive(true);
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

        gameObject.transform.position = herringStorageArea;

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            
        }

    }
}
