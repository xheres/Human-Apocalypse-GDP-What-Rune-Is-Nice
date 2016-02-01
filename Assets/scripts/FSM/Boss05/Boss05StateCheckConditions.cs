// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class Boss05StateCheckCondition : Boss05State
{
    bool hasEntered = false;

    Boss05State nextState;

    Transform player;
    int attackOrMove;

    public Boss05StateCheckCondition(Boss05FSM _FSM)
    {
        m_Boss05FSM = _FSM;
    }

    public override void Enter()
    {
        if (!hasEntered)
        {
            player = GameObject.Find("Player").transform;
        }

        Execute();
    }

    public override void Execute()
    {
        attackOrMove = Random.Range(0, 2);



        if(attackOrMove == 0) //Attack
        {
            nextState = new Boss05StateFire(m_Boss05FSM);
        }
        if(attackOrMove == 1) //Move
        {
            nextState = new Boss05StateMove(m_Boss05FSM);
        }
    }

    public override void Exit()
    {
        m_Boss05FSM.ChangeState(nextState);
    }
}
