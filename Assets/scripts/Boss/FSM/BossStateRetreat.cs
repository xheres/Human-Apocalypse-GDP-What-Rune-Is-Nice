using UnityEngine;
using System.Collections;

public class BossStateRetreat : BossState {

    public BossStateRetreat(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {

    }

    public override void Execute()
    {
        Debug.Log("Retreat");
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
