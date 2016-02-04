using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceController : MonoBehaviour 
{
    int stage;
    int curStage = 0;
    float dist = 0.0f;
    bool isBossStage = false;
    float speed;
    bool isChangingStage = false;

    [SerializeField] float maxDist = 60.0f;
    [SerializeField] float bossDist = 60.0f;

    //dev
    Text devText;
    Text devBossText;

    GameController gameController;
    FadeInOut fader;

    MeshRenderer[] bg = new MeshRenderer[3];

    void Start()
    {
        devText = GameObject.Find("Distance Text").GetComponent<Text>();
        devBossText = GameObject.Find("Boss Text").GetComponent<Text>();
        fader = GameObject.Find("Fader").GetComponent<FadeInOut>();
        gameController = GameObject.Find("_GameController").GetComponent<GameController>();

        bg[0] = GameObject.Find("Road_BG").GetComponent<MeshRenderer>();
        bg[1] = GameObject.Find("Beach_BG").GetComponent<MeshRenderer>();
        bg[2] = GameObject.Find("Forest_BG").GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!isChangingStage)
        {
            dist += Time.deltaTime;
            stage = (int)dist / ((int)maxDist + (int)bossDist);
        }

        if (dist / ((stage * (maxDist + bossDist)) + maxDist) >= 0.9f || isChangingStage)
        {
            isBossStage = true;
        }
        else
        {
            isBossStage = false;
        }

        if(curStage != stage)
        {
            if(!isChangingStage)
            {
                curStage = stage;
                isChangingStage = true;
                gameController.StageEnd();
                Invoke("changeBG", 1.5f);
                Invoke("StartNextStage", 3.0f);
            }
        }

        UpdateUI();
    }

    void StartNextStage()
    {
        gameController.stageStart();
        isChangingStage = false;
    }

    void changeBG()
    {
        // Disable all BG first
        for (int i = 0; i<3; i++)
        {
            bg[i].enabled = false;
        }

        bg[stage].enabled = true;
    }


    void UpdateUI()
    {
        devText.text = "Stage : " + (stage + 1).ToString()
                     + "\nDistance : " + (int)dist + " / " + ((stage + 1) * (maxDist + bossDist)).ToString();

        if(dist / ((stage * (maxDist + bossDist)) + maxDist) >= 1.0f)
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

    public int GetStage()
    {
        return stage;
    }
}
