// Lucas Lim
// P01
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeStateRetreat : MeleeState {

    bool retreat = false;

    MeleeState nextState;

	public MeleeStateRetreat(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
    {
        if(!retreat)
        {
            // make the enemy retreat. like move out of the map from its initial position and move up
            nextState = new MeleeStateDeleteEntity(m_MeleeFSM);
        }

        Execute();

    }

    public override void Execute()
    {
        Exit();
    }

    public override void Exit()
    {
        m_MeleeFSM.ChangeState(nextState);
    }
}
