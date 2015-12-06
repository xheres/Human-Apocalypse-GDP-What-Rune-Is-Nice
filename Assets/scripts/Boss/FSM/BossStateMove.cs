using UnityEngine;
using System.Collections;

public class BossStateMove : BossState {
    float speed = 0.05f;
    public BossStateMove(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        Execute();
    }

    public override void Execute()
    {
        Debug.Log("Randomly moves a set amount of space");
    }

    public override void Exit()
    {

    }
}
