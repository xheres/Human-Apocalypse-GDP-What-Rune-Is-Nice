using UnityEngine;
using System.Collections;

public class BossStateCreateMuzzle : BossState {

   
    [SerializeField] GameObject[] muzzles = new GameObject[3];
    GameObject prevMuzzle;
    GameObject chosenMuzzle;
    GameObject Boss;
    EnemyProperties enemyProp;

    bool hasEntered = false;

    public BossStateCreateMuzzle(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Boss = GameObject.Find("Boss_1");
            enemyProp = Boss.GetComponent<EnemyProperties>();
        }
        Execute();
    }

    public override void Execute()
    {
        int i = Random.Range(0, 3);
        chosenMuzzle = muzzles[i];
        while (chosenMuzzle == prevMuzzle)
        {
            i = Random.Range(0, 2);
            chosenMuzzle = muzzles[i];
        }
        enemyProp.setMuzzle(chosenMuzzle);
        Debug.Log("Create the muzzle");
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
