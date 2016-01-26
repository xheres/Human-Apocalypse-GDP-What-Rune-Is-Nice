//Name: Jared Koh
//Admin No: 1402535G
//Class: P01

using UnityEngine;
using System.Collections;

public class AimedStateRetreat : AimedState {

	public AimedStateRetreat(AimedFSM _FSM)
    {
        m_AimedFSM = _FSM;
    }

    public override void Enter()
    {
        Execute();
    }

    public override void Execute()
    {
        //Enemy will slowly retreat out of the screen.
        Exit();
    }

    public override void Exit()
    {
        m_AimedFSM.ChangeState(m_AimedFSM.ReturnNextState());
    }
}
