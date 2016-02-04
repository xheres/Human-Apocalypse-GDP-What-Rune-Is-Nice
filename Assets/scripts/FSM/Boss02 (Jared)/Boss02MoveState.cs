using UnityEngine;
using System.Collections;

public class Boss02MoveState : IBossState{

    private readonly StatePatternBoss02 boss02;

    [SerializeField] GameObject boss;


        public Boss02MoveState(StatePatternBoss02 statePatternBoss02)
    {
        boss02 = statePatternBoss02;
    }

    public void UpdateState()
    {
        Move();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToSpawnState()
    {
        Debug.Log("Can't transition to spawn state");
    }

    public void ToMoveState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToAttackState()
    {
        boss02.currentState = boss02.attackState;
    }

    public void ToRetreatState()
    {
        boss02.currentState = boss02.retreatState;
    }

    private void Move()
    {
        if (boss02.dirRight == true)
        {
            boss.transform.Translate(Vector2.right * boss02.speed * Time.deltaTime);
        }

        else
        {
            boss.transform.Translate(Vector2.left * boss02.speed * Time.deltaTime);
        }

        if (boss.transform.position.x >= 1.8)
        {
            boss02.dirRight = false;
        }

        if (boss.transform.position.x <= -1.8)
        {
            boss02.dirRight = true;
        }

        if (boss.transform.position.x < 0.1 && boss.transform.position.x > -0.1)
        {
            boss02.counter++;
        }

        if (boss02.counter++ == 3)
        {
            ToAttackState();
        }

    }

}
