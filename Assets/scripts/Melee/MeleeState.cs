using UnityEngine;
using System.Collections;

public abstract class MeleeStates
{
    protected MeleeFSM m_MeleeFSM;

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();


}
