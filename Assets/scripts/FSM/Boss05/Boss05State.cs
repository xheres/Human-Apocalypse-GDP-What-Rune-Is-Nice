// Done by 1406990J | Aaron Tan | P01 

using UnityEngine;
using System.Collections;

public abstract class Boss05State
{
    protected Boss05FSM m_Boss05FSM;

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
