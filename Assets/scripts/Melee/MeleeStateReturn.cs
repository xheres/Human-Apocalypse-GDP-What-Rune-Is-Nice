// Lucas Lim
// P01
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeStateReturn : MeleeState {

    bool goBack = false;

    MeleeState nextState;



	public MeleeStateReturn(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
    {
        if(!goBack)
        {
            if (contact)
            {
                // make the entity go back to its original position as it reaches the end of the screen (bottom)
                nextState = new MeleeStateIdle(m_MeleeFSM);
            }
            
            goBack = true;
        }

        Execute();
    }

    public override void Execute()
    {
        Contact();
    }

    public override void Exit()
    {
        m_MeleeFSM.ChangeState(nextState);
    }
    void Contact()
    {
        //makes it so tht if enemy comes in contact with bottom of the screen, goes back to original position
    }
}
