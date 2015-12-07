//Name: Jared Koh
//Admin No: 1402535G
//Class: P01

using UnityEngine;
using System.Collections;

public class AimedStateSpawn : AimedState {

    bool hasEntered = false;

    public AimedStateSpawn(AimedFSM _FSM)
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
        Debug.Log("Aimed enemy spawns");
        Exit();
    }

    public override void Exit()
    {
        m_AimedFSM.ChangeState(m_AimedFSM.ReturnNextState());
    }
}
