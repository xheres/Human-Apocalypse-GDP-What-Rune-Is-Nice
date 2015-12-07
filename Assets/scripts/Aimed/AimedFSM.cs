//Name: Jared Koh
//Admin No: 1402535G
//Class: P01


using UnityEngine;
using System.Collections;

public class AimedFSM : MonoBehaviour {

    GameObject Aimed;
    EnemyProperties enemyProp;
    int nAmmo;

    public enum eAimedState
    {
        Spawn,
        CreateMuzzle,
        Attack,
        Retreat,
        DeleteEntity
    }

    AimedState m_StateSpawn;
    AimedState m_StateCreateMuzzle;
    AimedState m_StateAttack;
    AimedState m_StateRetreat;
    AimedState m_StateDeleteEntity;

    AimedState m_CurrentState;
    AimedState m_LastState;


	void Start () 
    {
        m_StateSpawn = new AimedStateSpawn(this);
        m_StateCreateMuzzle = new AimedStateCreateMuzzle(this);
        m_StateAttack = new AimedStateAttack(this);
        m_StateRetreat = new AimedStateRetreat(this);
        m_StateDeleteEntity = new AimedStateDeleteEntity(this);


        Aimed = GameObject.Find("Aimed");
        enemyProp = Aimed.GetComponent<EnemyProperties>();

        ChangeState(eAimedState.Spawn);

	}
	
	void Update () 
    {
        m_CurrentState.Enter();
	}

    public eAimedState ReturnNextState()
    {
        nAmmo = enemyProp.getAmmo();
        if (m_CurrentState == m_StateSpawn) //checks current state, then returns the next state
        {
            return eAimedState.CreateMuzzle;
        }

        if (m_CurrentState == m_StateCreateMuzzle)
        {
            return eAimedState.Attack;
        }

        if (m_CurrentState == m_StateAttack)
        {
            if (nAmmo <= 0)
            {
                return eAimedState.Retreat;
            }
        }

        return eAimedState.DeleteEntity;
    }

    public void ChangeState(eAimedState _newState)
    {
        switch (_newState)
        {
            case eAimedState.Spawn: m_CurrentState = m_StateSpawn; break;
            case eAimedState.CreateMuzzle: m_CurrentState = m_StateCreateMuzzle; break;
            case eAimedState.Attack: m_CurrentState = m_StateAttack; break;
            case eAimedState.Retreat: m_CurrentState = m_StateRetreat; break;
            case eAimedState.DeleteEntity: m_CurrentState = m_StateDeleteEntity; break;
        }

        m_CurrentState.Enter();

    }

}
