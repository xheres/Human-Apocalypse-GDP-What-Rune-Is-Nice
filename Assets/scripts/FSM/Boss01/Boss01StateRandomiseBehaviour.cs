using UnityEngine;
using System.Collections;

public class Boss01StateRandomiseBehaviour : Boss01State {
    bool hasEntered = false;
    Boss01FSM Boss;
	public Boss01StateRandomiseBehaviour(Boss01FSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Boss = GameObject.Find("Boss01").GetComponent<Boss01FSM>();
        }
        Execute();
        Debug.Log("Started random");
    }

    public override void Execute()
    {

        Boss.RandomBehavior();
        Exit();
    }

    public override void Exit()
    {
        Debug.Log("returned from random behav");
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
