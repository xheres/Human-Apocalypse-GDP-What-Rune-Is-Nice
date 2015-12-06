//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class BossStateDeleteMuzzle : BossState {
    bool hasEntered = false;
    public BossStateDeleteMuzzle(BossFSM _FSM)
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
        Debug.Log("Delete Muzzle");
        Exit();
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
