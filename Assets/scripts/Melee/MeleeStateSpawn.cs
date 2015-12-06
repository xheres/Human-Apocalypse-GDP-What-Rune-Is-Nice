// Lucas Lim
// P01
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeStateSpawn : MeleeState {

    bool spawn = false;

    GameObject meleeEnemy;
    MeleeState nextState;

    public MeleeStateSpawn(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
    {
        if (!spawn)
        {
            nextState = new MeleeStateIdle(m_MeleeFSM);

            spawn = true;
        }

        Execute();
    }

    public override void Execute()
    {
        MonoBehaviour.Instantiate(meleeEnemy, new Vector3(0, 0, 0), Quaternion.identity);

        Exit();
    }

    public override void Exit()
    {
        m_MeleeFSM.ChangeState(nextState);
    }
}
