using UnityEngine;
using System.Collections;

public class Boss02SpawnState : IBossState {

    private readonly StatePatternBoss02 boss02;

    [SerializeField] GameObject boss;

    public Boss02SpawnState(StatePatternBoss02 statePatternBoss02)
    {
        boss02 = statePatternBoss02;
    }

    public void UpdateState()
    {
        Spawn();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToSpawnState()
    {
        Debug.Log("Can't transition to same state!");
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

    private void Spawn()
    { 
        // Boss will spawn and move to 6.5f of Y-axis
        MonoBehaviour.Instantiate(boss, new Vector3(0, 6.5f, 0), Quaternion.identity);
        ToMoveState();
    }


}
