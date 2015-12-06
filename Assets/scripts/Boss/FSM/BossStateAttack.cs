using UnityEngine;
using System.Collections;

public class BossStateAttack : BossState {
    bool hasEntered = false;
    int nShots = 0;
    int nShotCounter;
    GameObject Boss;
    EnemyProperties enemyProp;
    
    public BossStateAttack(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        if (hasEntered == false)
        {
            nShotCounter = nShots;
            Boss = GameObject.Find("Boss_1");
            enemyProp = Boss.GetComponent<EnemyProperties>();
            int nAmmo = enemyProp.getAmmo();
        }
        Execute();
    }

    public override void Execute()
    {
        //shoot based on the muzzle until a certain amount of shots, while reducing maxammo by 1 each time by calling UseAmmo
        if (nShotCounter <11)
        {
            Debug.Log("Shoot");
            nShotCounter++;
            enemyProp.UseAmmo();
        }
        else
        {
            Exit();
        }
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
