using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner_Script : MonoBehaviour 
{
    private int curStage;
    private int enemyIndex;
    private int prevIndex;
    private bool enemyOnField;
    [SerializeField] private GameObject[] enemySet;

    private int stageOffset;

    void Update()
    {
        if (!enemyOnField)
            Spawn();
    }

    void Spawn()
    {
        SetEnemySet(curStage);
        Instantiate(enemySet[0], transform.position, Quaternion.identity);
        enemyOnField = true;
    }

    void SetEnemySet(int stage)
    {
        stageOffset = (stage - 1) * 10;

        enemyIndex = Random.Range(0 + stageOffset, 9 + stageOffset);

        if(prevIndex == enemyIndex)
            enemyIndex = Random.Range(0 + stageOffset, 9 + stageOffset);
    }

    public void NoEnemiesLeft()
    {
        enemyOnField = true;
    }
}
