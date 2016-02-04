// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class Boss05StateSpawn : Boss05State
{
    bool hasEntered = false;

    Boss05State nextState;

    public Boss05StateSpawn(Boss05FSM _FSM)
    {
        m_Boss05FSM = _FSM;
    }

    public override void Enter()
    {
        if (!hasEntered)
        {
            nextState = new Boss05StateCheckConditions(m_Boss05FSM);

            hasEntered = true;
        }

        Execute();
    }

    public override void Execute()
    {
        m_Boss05FSM.getTransform().position = new Vector3(0, m_Boss05FSM.getYPos(), 0);
        // Nothing to do after spawning, exit to next state
        Exit();
    }

    public override void Exit()
    {
        // Nothing to change, goes to next state
        m_Boss05FSM.ChangeState(nextState);
    }
}
