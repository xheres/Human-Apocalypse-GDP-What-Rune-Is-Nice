// Lucas Lim
// P01
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeStateIdle : MeleeState {

    bool idle = false;

    MeleeState nextState;
    float time;
    [SerializeField] float timer = 4.0f;

    


    public MeleeStateIdle(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
    {
        if (!idle)
        {
            nextState = new MeleeStateAttack(m_MeleeFSM);
            time = timer;

            idle = true;
        }

        Execute();
    }

    public override void Execute()
    {
        Timer();
    }

    public override void Exit()
    {
        m_MeleeFSM.ChangeState(nextState);
    }

    void Timer()
    {
        timer -= Timer.deltaTime;
            if (timer % 4 < 0)
        {
            // enemy will attack again

            Exit();
        }
    }
}
