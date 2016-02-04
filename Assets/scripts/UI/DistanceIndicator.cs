using UnityEngine;
using System.Collections;

public class DistanceIndicator : MonoBehaviour 
{
    DistanceController distanceController;

    float stagePosDiff = 0.6f;
    float startPos = 6.7f;
    float endPos = 1.3f;
    Vector3 newPos;

    void Start()
    {
        distanceController = GameObject.Find("_DistanceController").GetComponent<DistanceController>();
    }

    void Update()
    {
        if (!distanceController.GetChangeStageStatus())
        {
            newPos = new Vector3(3.0f, startPos - ((distanceController.GetCurDist() / distanceController.GetEndDist()) * stagePosDiff), 0.0f);
            transform.position = newPos;
        }
    }
}
