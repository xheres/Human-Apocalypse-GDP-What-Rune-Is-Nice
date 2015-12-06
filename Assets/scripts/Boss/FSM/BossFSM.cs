//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class BossFSM : MonoBehaviour {
    //initialize variables
    GameObject Boss;
    EnemyProperties enemyProp;
    int nAmmo;
    bool changedMove = false;
public enum eBossState
    {
        Spawn,
        CreateMuzzle,
        DeleteMuzzle,
        Attack,
        Retreat,
        DeleteEntity,
        Move
       
    }

    BossState m_StateSpawn;
    BossState m_StateCreateMuzzle;
    BossState m_StateDeleteMuzzle;
    BossState m_StateAttack;
    BossState m_StateRetreat;
    BossState m_StateDeleteEntity;
    BossState m_StateMove;
    BossState m_CurrentState;
    BossState m_LastState;

    void Start ()
    {
        m_StateSpawn = new BossStateSpawn(this);
        m_StateCreateMuzzle = new BossStateCreateMuzzle(this);
        m_StateDeleteMuzzle = new BossStateDeleteMuzzle(this);
        m_StateAttack = new BossStateAttack(this);
        m_StateRetreat = new BossStateRetreat(this);
        m_StateDeleteEntity = new BossStateDeleteEntity(this);
        m_StateMove = new BossStateMove(this);

         Boss = GameObject.Find("Boss_1");
         enemyProp = Boss.GetComponent<EnemyProperties>();

         ChangeState(eBossState.Spawn);
    }
	// Update is called once per frame
	void Update () //update states
    {
        m_CurrentState.Enter();

	}

    public eBossState ReturnNextState() //returns the next state in line
    {
        nAmmo = enemyProp.getAmmo();
        if (m_CurrentState == m_StateSpawn)
        {
            return eBossState.CreateMuzzle;
        }
        if (m_CurrentState == m_StateCreateMuzzle)
        {
            return eBossState.Move;
        }
        if (m_CurrentState == m_StateMove)
        {
            return eBossState.Attack;
        }
        if (m_CurrentState == m_StateAttack)
        {
            if (nAmmo > 0)
            {
                return eBossState.DeleteMuzzle;
            }
            if (nAmmo <= 0)
            {
                return eBossState.Retreat;
            }
        }
        if (m_CurrentState == m_StateDeleteMuzzle)
        {
            return eBossState.CreateMuzzle;
        }
        return eBossState.DeleteEntity;
    }

    public void ChangeState (eBossState _newState) //change the current state to the selected state
    {
        switch (_newState)
        {
            case eBossState.Spawn: m_CurrentState = m_StateSpawn; break;
            case eBossState.CreateMuzzle: m_CurrentState = m_StateCreateMuzzle; break;
            case eBossState.DeleteMuzzle: m_CurrentState = m_StateDeleteMuzzle; break;
            case eBossState.Attack: m_CurrentState = m_StateAttack; break;
            case eBossState.Retreat: m_CurrentState = m_StateRetreat; break;
            case eBossState.DeleteEntity: m_CurrentState = m_StateDeleteEntity; break;
            case eBossState.Move: m_CurrentState = m_StateMove; break;
        }
        m_CurrentState.Enter();
    }
}
