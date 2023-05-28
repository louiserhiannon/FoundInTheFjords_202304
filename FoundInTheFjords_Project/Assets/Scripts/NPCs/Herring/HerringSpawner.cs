using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerringSpawner : MonoBehaviour
{
    public static HerringSpawner HS;
    public GameObject herringPrefab;
    public int numberOfHerring;
    public List<GameObject> herringList;
    public bool useGravity;

    private void Awake()
    {
        HS = this;
    }
    void Start()
    {
        for(int i = 0; i < numberOfHerring; i++)
        {
            herringList.Add(Instantiate(herringPrefab, EatingController.EC.herringStorageArea.position, Quaternion.identity));
            herringList[i].gameObject.SetActive(false);
            if (herringList[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.useGravity = false;
                rigidbody.isKinematic = true;
            }
        }
    }

   
}
