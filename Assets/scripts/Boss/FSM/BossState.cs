//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public abstract class BossState
{

    protected BossFSM m_BossFSM;


    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
