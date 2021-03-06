﻿// Lucas Lim 
// P01 
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeStateDeleteEntity : MeleeState
{

    bool delete = false;
    public MeleeStateDeleteEntity(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
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

