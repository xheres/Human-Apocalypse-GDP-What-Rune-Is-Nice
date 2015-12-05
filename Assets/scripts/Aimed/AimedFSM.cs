using UnityEngine;
using System.Collections;

public class AimedFSM : MonoBehaviour {

    public enum eAimedState
    {
        Spawn,
        CreateMuzzle,
        Attack,
        Retreat,
        DeleteEntity,
        Move
    }

    AimedState m_StateSpawn;
    AimedState m_StateCreateMuzzle;
    AimedState m_StateAttack;
    AimedState m_StateRetreat;
    AimedState m_StateDeleteEntity;
    AimedState m_StateMove;
    AimedState m_CurrentState;
    AimedState m_LastState;


	void Start () 
    {
        m_StateSpawn = new AimedStateSpawn(this);
        m_StateCreateMuzzle = new AimedStateCreateMuzzle(this);
        m_StateAttack = new AimedStateAttack(this);
        m_StateRetreat = new AimedStateRetreat(this);
        m_StateDeleteEntity = new AimedStateDeleteEntity(this);
        m_StateMove = new AimedStateMove(this);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
