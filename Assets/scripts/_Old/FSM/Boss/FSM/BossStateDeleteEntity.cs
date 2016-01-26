//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class BossStateDeleteEntity :BossState {
    bool hasEntered = false;
    public BossStateDeleteEntity(BossFSM _FSM)
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
        Exit();
    }

    public override void Exit()
    {
        Debug.Log("Delete Boss GameObject");
    }
}
