//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class BossStateMove : BossState {
    float speed = 0.05f;
    int Move;
    public BossStateMove(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        Move = Random.Range(0, 2);
        Execute();
    }

    public override void Execute()
    {
        if (Move == 0)
        {
            Exit();
        }

        if (Move == 1)
        {
            Debug.Log("Randomly moves a set amount of space in the X and Y direction in multiples of 1, not exceeding 3 units for each axis");
            Exit();
        }
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
