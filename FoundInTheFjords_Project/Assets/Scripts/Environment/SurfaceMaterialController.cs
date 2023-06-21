using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceMaterialController : MonoBehaviour
{
    public DepthCalculator depthCalculator;
    public Material transparentWaterSurface;
    public Material opaqueWaterSurface;
    private MeshRenderer surfaceRenderer;
    private bool changeToTransparent = false;
    private bool changeToOpaque = true;
    // Start is called before the first frame update
    void Start()
    {
        surfaceRenderer = GetComponent<MeshRenderer>();
        surfaceRenderer.materials[0] = transparentWaterSurface;
    }

    // Update is called once per frame
    void Update()
    {
        if(depthCalculator.headsetDepthCorrected >= 0)
        {
            if(changeToOpaque)
            {
                Material[] materials = surfaceRenderer.materials;
                materials[0] = opaqueWaterSurface;
                surfaceRenderer.materials = materials;
                changeToOpaque = false;
                changeToTransparent = true;
            }
        }
        else
        {
            if (changeToTransparent)
            {
                Material[] materials = surfaceRenderer.materials;
                materials[0] = transparentWaterSurface;
                surfaceRenderer.materials = materials;
                changeToOpaque = true;
                changeToTransparent = false;
            }
        }
    }
}
