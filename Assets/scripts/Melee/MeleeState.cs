// Lucas Lim 
// P01 
// 1402476D

using UnityEngine;
using System.Collections;

public abstract class MeleeState
{
    protected MeleeFSM m_MeleeFSM;

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();


}
