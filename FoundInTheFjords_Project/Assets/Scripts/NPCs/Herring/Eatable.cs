using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    private Material herringMaterial;
    private Color hoverColor;
    private Color nonHoverColor;
    private float lifetime = 0;
    public bool hoverActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        herringMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        hoverColor = Color.magenta;
        nonHoverColor = Color.white;

    }

    private void Update()
    {
        lifetime += Time.deltaTime;
        if(lifetime >= EatingController.EC.herringLifetime)
        {
            Destroy(gameObject);
            for (int i = EatingController.EC.eatableHerrings.Count - 1; i > -1; i--)
            {
                if (EatingController.EC.eatableHerrings[i] == null)
                {
                    EatingController.EC.eatableHerrings.RemoveAt(i);
                }
            }
        }
    }

    public void OnHoverStart()
    {
        herringMaterial.color = hoverColor;
        hoverActivated = true;
    }

    public void OnHoverEnd()
    {
        herringMaterial.color = nonHoverColor;
        hoverActivated = false;
    }


}
