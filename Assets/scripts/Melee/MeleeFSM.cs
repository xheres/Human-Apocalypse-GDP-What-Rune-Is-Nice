using UnityEngine;
using System.Collections;

public class MeleeFSM : MonoBehaviour {

    public enum eMeleeState
    {
        Spawn,
        Idle,
        Attack,
        Explode,
        Return,
        Retreat,
        DeleteEntity
    }

    MeleeState m_StateSpawn;
    MeleeState m_StateIdle;
    MeleeState m_StateAttack;
    MeleeState m_StateExplode;
    MeleeState m_StateReturn;
    MeleeState m_StateRetreat;
    MeleeState m_StateDeleteEntity;
    MeleeState m_CurrentState;
    MeleeState m_LastState;


	void Start () 
    {
        m_StateSpawn = new MeleeStateSpawn(this);
        m_StateIdle = new MeleeStateIdle(this);
        m_StateAttack = new MeleeStateAttack(this);
        m_StateCreateExplode = new MeleeStateExplode(this);
        m_StateReturn = new MeleeStateReturn(this);
        m_StateRetreat = new MeleeStateRetreat(this);
        m_StateDeleteEntity = new MeleeStateDeleteEntity(this);
        m_StateMove = new MeleeStateMove(this);

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
