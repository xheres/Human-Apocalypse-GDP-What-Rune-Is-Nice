// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class Boss05StateMove : Boss05State
{
    bool hasEntered = false;

    Boss05State nextState;

    [SerializeField] Vector2[] wayPoints;
    Transform myTransform;

    public Boss05StateMove(Boss05FSM _FSM)
    {
        m_Boss05FSM = _FSM;
    }

    public override void Enter()
    {
        if(!hasEntered)
        {
            myTransform = m_Boss05FSM.transform;
            nextState = new Boss05StateFire(m_Boss05FSM);

            hasEntered = true;
        }
        Execute();
    }

    public override void Execute()
    {
        Vector3.Lerp(myTransform.position, wayPoints[m_Boss05FSM.getMoveIndex()], 15 * Time.deltaTime);
    }

    public override void Exit()
    {
        m_Boss05FSM.ChangeState(nextState);
    }
}
