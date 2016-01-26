//Name: Jared Koh
//Admin No: 1402535G
//Class: P01

using UnityEngine;
using System.Collections;

public abstract class AimedState
{
    protected AimedFSM m_AimedFSM;

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();


}
