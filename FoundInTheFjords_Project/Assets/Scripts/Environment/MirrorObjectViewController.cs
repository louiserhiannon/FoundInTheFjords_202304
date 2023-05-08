using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorObjectViewController : MonoBehaviour
{
    public List<GameObject> mirrorObjects;
    //public GameObject mirrorOrca;
    //public GameObject mirrorJelly;
    //public GameObject upperSeaBox;
    public GameObject terrain;
    public MeshRenderer waterSurfaceRenderer;
    private Material surfaceMaterial;
    private Color surfaceColour;

    private void Start()
    {
        surfaceMaterial = waterSurfaceRenderer.material;
        terrain.SetActive(false);
    }

    void Update()
    {
        if (DepthCalculator.dc.headsetDepthCorrected >= 0)
        {
            //switches off mirror orca, mirror jelly, and upper seabox
            for (int i = 0; i < mirrorObjects.Count; i++)
            {
                mirrorObjects[i].SetActive(false);
            }
            terrain.SetActive(true);
            SetSurfaceAlpha();
        }
        else
        {
            //switches on mirror objects, mirror jelly, and upper seabox
            for (int i = 0; i < mirrorObjects.Count; i++)
            {
                mirrorObjects[i].SetActive(true);
            }
            terrain.SetActive(false);
            ResetSurfaceAlpha();
        }
    }
    private void SetSurfaceAlpha()
    {
        surfaceColour = surfaceMaterial.color;
        surfaceColour.a = 1.0f;
        surfaceMaterial.color = surfaceColour;
    }

    private void ResetSurfaceAlpha()
    {
        surfaceColour = surfaceMaterial.color;
        surfaceColour.a = 0.3f;
        surfaceMaterial.color = surfaceColour;
    }
}
