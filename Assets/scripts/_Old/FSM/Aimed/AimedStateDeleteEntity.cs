//Name: Jared Koh
//Admin No: 1402535G
//Class: P01

using UnityEngine;
using System.Collections;

public class AimedStateDeleteEntity : AimedState {

    bool hasEntered = false;
    public AimedStateDeleteEntity(AimedFSM _FSM)
    {
        m_AimedFSM = _FSM;
    }

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Execute();
            hasEntered = true;
        }
    }

    public override void Execute()
    {
        Exit();
    }

    public override void Exit()
    {
        //Delete enemy gameobject
    }
}
