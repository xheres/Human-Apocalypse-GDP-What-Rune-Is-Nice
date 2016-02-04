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
    int rand;

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
                    SetEnemyGroup(distanceController.GetStage());
                    rand = Random.Range((0 + stageOffset), (9 + stageOffset));
                    if (enemyGroup[rand] != null)
                    {
                        createdGroup = Instantiate(enemyGroup[rand], transform.position, Quaternion.identity) as GameObject;
                    }
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
        stageOffset = stage * 10;
    }
}
