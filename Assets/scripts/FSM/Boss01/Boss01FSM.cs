//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class Boss01FSM : MonoBehaviour {
    //initialize variables
    DistanceController distanceController;
    int random = 0;
    public bool bossSpawned = false;
    public GameObject[] Muzzles;
    public GameObject muzzle;
    public GameObject Boss01;
public enum eBossState
    {
        Spawn,
        Attack,
        ChangeAttack,
        RandomiseBehaviour,
        Retreat,
        DeleteEntity,
        Move
       
    }

    Boss01State m_StateSpawn;
    Boss01State m_StateAttack;
    Boss01State m_StateChangeAttack;
    Boss01State m_StateRandomiseBehaviour;
    Boss01State m_StateMove;
    Boss01State m_CurrentState;
    Boss01State m_LastState;

    void Start ()
    {
        m_StateSpawn = new Boss01StateSpawn(this);
        m_StateAttack = new Boss01StateAttack(this);
        m_StateChangeAttack = new Boss01StateChangeAttack(this);
        m_StateRandomiseBehaviour = new Boss01StateRandomiseBehaviour(this);
        m_StateMove = new Boss01StateMove(this);
        distanceController = GameObject.Find("_DistanceController").GetComponent<DistanceController>(); 

         ChangeState(eBossState.Spawn);
    }
	// Update is called once per frame
	void Update () //update states
    {
        if (distanceController.checkBossStage() && !bossSpawned)
        {
            m_CurrentState.Enter();
            bossSpawned = true;
        }
      

	}

    public eBossState ReturnNextState() //returns the next state in line
    {
        if (m_CurrentState == m_StateSpawn)
        {
            return eBossState.ChangeAttack;
        }
        if (m_CurrentState == m_StateAttack )
        {
            return eBossState.ChangeAttack;
        }
        if (m_CurrentState == m_StateChangeAttack)
        {
            return eBossState.RandomiseBehaviour;
        }
        if (m_CurrentState == m_StateRandomiseBehaviour && random == 1 || random == 0)
        {
            Debug.Log("returned attack1");
            return eBossState.Attack;
            
        }
        if (m_CurrentState == m_StateRandomiseBehaviour && random == 2)
        {
            Debug.Log("returned attack2");
                return eBossState.Move;
         
        }
        if (m_CurrentState == m_StateMove)
        {
            return eBossState.Attack;
        }
        return eBossState.ChangeAttack;
    }

    public void ChangeState (eBossState _newState) //change the current state to the selected state
    {
        switch (_newState)
        {
            case eBossState.Spawn: m_CurrentState = m_StateSpawn; break;
            case eBossState.ChangeAttack: m_CurrentState = m_StateChangeAttack; break;
            case eBossState.RandomiseBehaviour: m_CurrentState = m_StateRandomiseBehaviour; break;
            case eBossState.Attack: m_CurrentState = m_StateAttack; break;
            case eBossState.Move: m_CurrentState = m_StateMove; break;
        }
        Debug.Log(m_CurrentState);
        m_CurrentState.Enter();
    }

    public void RandomBehavior()
    {
        random = Random.Range(1, 3);
    }
}
