using UnityEngine;
using System.Collections;

public class MeleeStateDeleteEntity : MeleeState
{

    bool delete = false;
    public MeleeStateDeleteEntity(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    void Start()
    {
        if (!delete)
        {
            delete = true;
        }

        Execute();
    }

    public override void Execute()
    {
        Exit();
    }

    public override void Exit()
    {
        
    }
}

