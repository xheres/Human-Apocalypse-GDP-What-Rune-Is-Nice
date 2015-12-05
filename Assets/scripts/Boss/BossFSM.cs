using UnityEngine;
using System.Collections;

public class BossFSM : MonoBehaviour {

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
    }
	// Update is called once per frame
	void Update () 
    {
	
	}
}
