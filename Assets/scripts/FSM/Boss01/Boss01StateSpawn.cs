//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class Boss01StateSpawn : Boss01State {
    bool hasEntered = false;
    Boss01FSM Boss;
    GameObject Boss01;
    [SerializeField]
    float y = 6.5f;

    public Boss01StateSpawn(Boss01FSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Boss = GameObject.Find("Boss01").GetComponent<Boss01FSM>();
            Boss01 = Boss.Boss01;

            Execute();
            hasEntered = true;
        }
    }

    public override void Execute()
    {
        if (Boss.bossSpawned == false)
        {
           // MonoBehaviour.Instantiate(Boss01, new Vector3(0, y, 0), Quaternion.identity);
            Boss.bossSpawned = true;
        }
        Exit();
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
