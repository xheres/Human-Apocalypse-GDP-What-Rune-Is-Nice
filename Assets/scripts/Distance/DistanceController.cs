using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceController : MonoBehaviour 
{
    int stage;
    float dist = 0;
    [SerializeField] float maxDist = 60;

    float speed;

    //dev
    Text devText;

    void Start()
    {
        devText = GameObject.Find("Distance Text").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        dist += 0.02f;
        UpdateUI();
    }

    void Update()
    {
        stage = (int)dist/(int)maxDist;
    }

    void UpdateUI()
    {
        devText.text = "Stage : " + stage
                     + "\nDistance : " + dist + " / " + ((stage + 1) * maxDist).ToString();
    }
}
