// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class Boss05StateSwitchAttack : Boss05State
{
    bool hasEntered = false;

    Boss05State nextState;

    [SerializeField] GameObject[] attackSet;
    GameObject attack;

    public Boss05StateSwitchAttack(Boss05FSM _FSM)
    {
        m_Boss05FSM = _FSM;
    }

    public GameObject getAttack()
    {
        return attack;
    }

    public override void Enter()
    {
        if (!hasEntered)
        {
            
        }

        Execute();
    }

    public override void Execute()
    {
        attack = attackSet[m_Boss05FSM.getAttackIndex()];
    }

    public override void Exit()
    {
        m_Boss05FSM.ChangeState(nextState);
    }
}
