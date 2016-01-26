using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner_Script : MonoBehaviour 
{
    int curStage;
    int enemyIndex;
    int prevIndex;
    bool enemyOnField;
    int stageOffset;

    GameObject createdGroup;
    DistanceController distanceController;

    [SerializeField] GameObject[] enemyGroup;

    

    void Start()
    {
        distanceController = GameObject.Find("_DistanceController").GetComponent<DistanceController>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (!distanceController.checkBossStage())
            {
                if (!enemyOnField)
                {
                    enemyOnField = true;
                    yield return new WaitForSeconds(0.5f);
                    SetEnemyGroup(curStage);
                    createdGroup = Instantiate(enemyGroup[0], transform.position, Quaternion.identity) as GameObject;
                }

                if (GameObject.FindWithTag("Enemy") == null)
                {
                    Destroy(createdGroup);
                    enemyOnField = false;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void SetEnemyGroup(int stage)
    {
        stageOffset = (stage - 1) * 10;

        enemyIndex = Random.Range(0 + stageOffset, 9 + stageOffset);

        if(prevIndex == enemyIndex)
            enemyIndex = Random.Range(0 + stageOffset, 9 + stageOffset);
    }
}
