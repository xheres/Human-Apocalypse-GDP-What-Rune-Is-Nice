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
        Debug.Log("Randomly moves a set amount of space in the X and Y direction in multiples of 1, not exceeding 3 units for each axis");
    }

    public override void Exit()
    {
        m_BossFSM.MoveChangeState();
    }
}
