using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceController : MonoBehaviour 
{
    static int stage;
    static float dist = 0.0f;
    bool isBossStage = false;
    float speed;

    [SerializeField] float maxDist = 60.0f;
    [SerializeField] float bossDist = 60.0f;

    //dev
    Text devText;
    Text devBossText;

    void Start()
    {
        devText = GameObject.Find("Distance Text").GetComponent<Text>();
        devBossText = GameObject.Find("Boss Text").GetComponent<Text>();
    }

    void Update()
    {
        dist += Time.deltaTime;
        stage = (int)dist/((int)maxDist + (int)bossDist);

        if (dist / (maxDist - stage) >= 0.9f)
        {
            isBossStage = true;
        }
        else
        {
            isBossStage = false;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        devText.text = "Stage : " + (stage + 1).ToString()
                     + "\nDistance : " + (int)dist + " / " + ((stage + 1) * (maxDist + bossDist)).ToString();

        if(dist/(maxDist - stage) >= 1.0f)
        {
            devBossText.enabled = true;
        }
        else
        {
            devBossText.enabled = false;
        }
    }

    public bool checkBossStage()
    {
        return isBossStage;
    }
}
