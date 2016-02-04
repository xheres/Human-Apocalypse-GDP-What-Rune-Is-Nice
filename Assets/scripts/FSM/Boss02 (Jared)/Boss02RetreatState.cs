using UnityEngine;
using System.Collections;

public class Boss02RetreatState : IBossState
{

    private readonly StatePatternBoss02 boss02;


    public Boss02RetreatState(StatePatternBoss02 statePatternBoss02)
    {
        boss02 = statePatternBoss02;
    }

    public void UpdateState()
    {
        Retreat();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToSpawnState()
    {
        boss02.currentState = boss02.spawnState;
    }

    public void ToMoveState()
    {
        boss02.currentState = boss02.moveState;
    }

    public void ToAttackState()
    {
        boss02.currentState = boss02.attackState;
    }

    public void ToRetreatState()
    {
        boss02.currentState = boss02.retreatState;
    }

    private void Retreat()
    {
        MonoBehaviour.Destroy(boss02.boss);
    }


}
