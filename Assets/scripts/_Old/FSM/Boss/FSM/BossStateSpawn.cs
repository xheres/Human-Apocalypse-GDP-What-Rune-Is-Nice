//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class BossStateSpawn : BossState {
    bool hasEntered = false;
    public BossStateSpawn(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Execute();
            hasEntered = true;
        }
    }

    public override void Execute()
    {
        //spawn boss warning sign
        Debug.Log("Spawn Boss Warning Sign");
        //Wait 
        Debug.Log("Waiting for 3 Seconds");
        //Spawn boss
        Debug.Log("Boss Spawned");
        //Call Exit
        Exit();
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
