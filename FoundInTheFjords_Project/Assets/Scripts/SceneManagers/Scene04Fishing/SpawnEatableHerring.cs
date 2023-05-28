using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEatableHerring : MonoBehaviour
{
    public static SpawnEatableHerring SH;
    public GameObject herringPrefab;
    public float minSpeed;
    public float maxSpeed;
    public float minRotateSpeed;
    public float maxRotateSpeed;
    public int numberOfSpawners;
    private int count = 0;

    private void Awake()
    {
        SH = this;
    }

    void Update()
    {
        if (Random.Range(1, 1000) < 15)
        {
           Spawn();    
        }
    }

    public void Spawn()
    {
        
        for (int i = 0; i < HerringSpawner.HS.herringList.Count; i++)
        {
            if (count < numberOfSpawners)
            {
                if (!HerringSpawner.HS.herringList[i].activeSelf)
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
            else
            {
                break;
            }
        }
        
        //Instantiate(herringPrefab, transform.position, Quaternion.identity);
        
        
    }
   


}
