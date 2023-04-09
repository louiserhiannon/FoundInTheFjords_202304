using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FM_Herring : FlockManager
{
    public GameObject flockerPrefab;
    
    //public GameObject[] allFlockers;
    
    
    //public Vector3 innerLimits = new (0f,0f, 0f);
    
    
    
    public override void Start()
    {
        base.Start();
        //allFlockers = new GameObject[numFlockers];
        for (int i = 0; i < numFlockers; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-outerLimits.x, outerLimits.x), Random.Range(-outerLimits.y, outerLimits.y), Random.Range(-outerLimits.z, outerLimits.z));
            //allFlockers[i] = Instantiate(flockerPrefab, pos, Quaternion.identity);
            allFlockers.Add(Instantiate(flockerPrefab, pos, Quaternion.identity));

        }

        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
