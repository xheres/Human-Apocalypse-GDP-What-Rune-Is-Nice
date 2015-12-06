﻿using UnityEngine;
using System.Collections;

public class BossStateRetreat : BossState {

    float retreatYPos = 9.2f;
    public BossStateRetreat(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        Execute();
    }

    public override void Execute()
    {
        Debug.Log("Retreat while y Pos not  < 9.2f ");
        Exit();
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
