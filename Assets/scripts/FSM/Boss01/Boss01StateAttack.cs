//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class Boss01StateAttack : Boss01State {
    bool hasEntered = false;
    Transform transform;
    GameObject muzzle;
    Boss01FSM Boss;
    bool spawned = false;
    
    
    public Boss01StateAttack(Boss01FSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Boss = GameObject.Find("Boss01").GetComponent<Boss01FSM>();
            transform = m_BossFSM.transform;
            muzzle = Boss.muzzle;
            hasEntered = true;
        }
        Execute();
        
    }

    public override void Execute()
    {
        {
            Debug.Log("Executed attack");
            if (spawned == false)
            {
                MonoBehaviour.Instantiate(muzzle, transform.position, Quaternion.identity);
                spawned = true;
                Debug.Log("spawned muzzle");
            }
            else if (GameObject.FindWithTag("muzzle") == null && spawned == true)
            {
                Exit();
                Debug.Log("exited from attack");
            }
            else if (spawned == true)
            {
                Debug.Log(spawned);
            }


            
        }

    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
