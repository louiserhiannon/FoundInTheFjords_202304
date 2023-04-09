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

    private void Awake()
    {
        SH = this;
    }

    void Update()
    {
        if (Random.Range(1, 1000) < 8)
        {
           Spawn();    
        }
    }

    public void Spawn()
    {
        
        Instantiate(herringPrefab, transform.position, Quaternion.identity);
        
        
    }
   


}
