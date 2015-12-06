using UnityEngine;
using System.Collections;

public class BossStateAttack : BossState {
    bool hasEntered = false;
    int nShots = 0;
    int nShotCounter;
    GameObject Boss;
    EnemyProperties enemyProp;
    int Move;
    
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
            Move = Random.Range(0, 2);
        }
        Execute();
    }

    public override void Execute()
    {
        if (Move == 0)
        {
            //shoot based on the muzzle until a certain amount of shots, while reducing maxammo by 1 each time by calling UseAmmo
            if (nShotCounter < 11)
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
        else if (Move == 1)
        {
            Exit();
        }
    }

    public override void Exit()
    {
        if (Move == 1)
        {
            m_BossFSM.MoveChangeState();
        }
        else if (Move == 0)
        {
            m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
        }
    }
}
