// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public class Boss05StateFire : Boss05State
{
    bool hasEntered = false;

    Boss05State nextState;

    Boss05StateSwitchAttack switchAttackScript;
    GameObject muzzleCreator;
    Transform myTransform;

    public Boss05StateFire(Boss05FSM _FSM)
    {
        m_Boss05FSM = _FSM;
    }

    public override void Enter()
    {
        if(!hasEntered)
        {
            switchAttackScript = m_Boss05FSM.GetComponent<Boss05StateSwitchAttack>();
            myTransform = m_Boss05FSM.transform;

            muzzleCreator = switchAttackScript.getAttack();
        }

        Execute();
    }

    public override void Execute()
    {
        if(m_Boss05FSM.getCanFire()) // Check if boss is allowed to fire
        {   
            MonoBehaviour.Instantiate(muzzleCreator, myTransform.position, Quaternion.identity); // Fire
            m_Boss05FSM.canFireCooldown();
        }
    }

    public override void Exit()
    {
        m_Boss05FSM.ChangeState(nextState);
    }
}
