using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orcaFinController : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer mirrorOrcaSkinnedMeshRenderer;
    [SerializeField]
    private Mesh orcaMesh;
    private int blendShapeCount;
    public Transform leftController;
    public Transform rightController;
    private float leftControllerX;
    private float rightControllerX;
    private float leftControllerXMax;
    private float rightControllerXMax;
    private float leftControllerXMin;
    private float rightControllerXMin;
    [SerializeField] private float blendRatioRight = 0f;
    [SerializeField] private float blendRatioLeft = 0f;
    [SerializeField] private float leftFinBlendShape;
    [SerializeField] private float rightFinBlendShape;
    //private List<float> blendRatios = new List<float>();

    private void Awake()
    {
        mirrorOrcaSkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        orcaMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        Debug.Log(orcaMesh.GetBlendShapeName(0));
        Debug.Log(orcaMesh.GetBlendShapeName(1));
    }
    // Start is called before the first frame update
    void Start()
    {
        leftControllerXMax = -0.50f;
        leftControllerXMin = -0.25f;
        rightControllerXMax = 0.50f;
        rightControllerXMin = 0.25f;

        blendShapeCount = orcaMesh.blendShapeCount;
        Debug.Log(blendShapeCount);
    }

    // Update is called once per frame
    void Update()
    {
        leftControllerX = leftController.transform.localPosition.x;
        rightControllerX = rightController.transform.localPosition.x;
        LeftFinControl(leftControllerX);
        RightFinControl(rightControllerX);
    }

    private void RightFinControl(float rightControllerX)
    {
        //note that because of mirror effect, right controller controls left fin
        blendRatioRight = Mathf.Clamp((1 - (rightControllerX - rightControllerXMin) * (rightControllerXMax - rightControllerXMin)) * 100, 0, 100);
        mirrorOrcaSkinnedMeshRenderer.SetBlendShapeWeight(0, blendRatioRight);
        rightFinBlendShape = mirrorOrcaSkinnedMeshRenderer.GetBlendShapeWeight(0);
        
    }

    private void LeftFinControl(float leftControllerX)
    {
        //note that because of mirror effect, left controller controls right fin
        blendRatioLeft = Mathf.Clamp((1 - (leftControllerX - leftControllerXMin) * (leftControllerXMax - leftControllerXMin)) * 100, 0, 100);
        mirrorOrcaSkinnedMeshRenderer.SetBlendShapeWeight(1, blendRatioLeft);
        leftFinBlendShape = mirrorOrcaSkinnedMeshRenderer.GetBlendShapeWeight(1);
    }

}
