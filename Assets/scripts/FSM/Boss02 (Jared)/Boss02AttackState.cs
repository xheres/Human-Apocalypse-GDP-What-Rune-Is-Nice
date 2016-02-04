using UnityEngine;
using System.Collections;

public class Boss02AttackState : IBossState
{

    private readonly StatePatternBoss02 boss02;


    public Boss02AttackState(StatePatternBoss02 statePatternBoss02)
    {
        boss02 = statePatternBoss02;
    }


    public void UpdateState()
    {
        Attack();
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


    private void Attack()
    {
        // Boss will choose the attacks in the stored array
        // Spawn them
        // Once the attack is done
        // If there are still attacks left,

        for (int i = 0; i < 5; i++)
        {

            if (boss02.spawned == false)
            {
                MonoBehaviour.Instantiate(boss02.muzzleSelect[i], boss02.boss.transform.position, Quaternion.identity);
                boss02.spawned = true;
            }

            else if (!GameObject.FindWithTag("muzzle") && boss02.spawned == true)
            {
                ToMoveState();
            }

            else if (i == boss02.muzzleSelect.Length)
            {
                ToRetreatState();
            }

        }
    }

}
