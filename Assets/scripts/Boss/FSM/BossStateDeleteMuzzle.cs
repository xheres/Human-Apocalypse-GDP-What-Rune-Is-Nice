using UnityEngine;
using System.Collections;

public class BossStateDeleteMuzzle : BossState {

    public BossStateDeleteMuzzle(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        Execute();
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
