using UnityEngine;
using System.Collections;

public class MeleeStateAttack : MeleeState {

    bool attack = false;
    bool hit = false;

    MeleeState nextState;

    

    public MeleeStateAttack(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
    {
        if (!attack)
        {

            // Transform.position something something
            // make the enemy dash forward towards the player in a straight line

            if(!hit)
            {
                nextState = new MeleeStateReturn(m_MeleeFSM);

                attack = true;
            }
            else
            {
                nextState = new MeleeStateExplode(m_MeleeFSM);

                attack = true;
            }
        }

        Execute();
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }

}
