//Matric Number: 1401169f, Name: Calvin, Class: P01
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
            hasEntered = true;
        }
        Execute();
    }

    public override void Execute()
    {
        {
            //shoot based on the muzzle until a certain amount of shots, while reducing maxammo by 1 each time by calling UseAmmo
            if (nShotCounter < 11)
            {
                Debug.Log("Shoot");
                nShotCounter++;
                enemyProp.UseAmmo(); //this takes away 1 from total ammo count
            }
            else
            {
                Exit();
            }
        }

    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
