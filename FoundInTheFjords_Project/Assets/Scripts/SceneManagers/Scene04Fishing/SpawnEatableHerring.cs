using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEatableHerring : MonoBehaviour
{
    public static SpawnEatableHerring SH;
    //public GameObject herringPrefab;
    public float minSpeed;
    public float maxSpeed;
    public float minRotateSpeed;
    public float maxRotateSpeed;
    public int numberOfSpawners;
    [SerializeField] private int count = 0;
    public bool spawnHerring = false;

    private void Awake()
    {
        SH = this;
        //StartCoroutine(Spawn());
       
    }

    //void Update()
    //{
    //    if (Random.Range(1, 1000) < 15)
    //    {
    //       count = 0;
    //        Spawn();    
    //    }
    //}

    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while (spawnHerring)
        {
            count = 0;
            yield return new WaitForSeconds(Random.Range(3f, 7f));
            for (int i = 0; i < HerringSpawner.HS.herringList.Count; i++)
            {
                if (!HerringSpawner.HS.herringList[i].activeSelf) 
                {
                    if (count < numberOfSpawners)
                    {
                        HerringSpawner.HS.herringList[i].SetActive(true);
                        if (HerringSpawner.HS.herringList[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                        {
                            if (HerringSpawner.HS.useGravity)
                            {
                                rigidbody.useGravity = true;
                                rigidbody.isKinematic = false;
                            }

                        }
                        count++;
                    }

                }
                

            }
            yield return new WaitForEndOfFrame();
            yield return null;
        
        }
        
        //Instantiate(herringPrefab, transform.position, Quaternion.identity);
        
        
    }
   


}
