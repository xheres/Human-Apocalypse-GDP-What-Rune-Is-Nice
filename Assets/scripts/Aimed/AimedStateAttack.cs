//Name: Jared Koh
//Admin No: 1402535G
//Class: P01

using UnityEngine;
using System.Collections;

public class AimedStateAttack : AimedState {
    bool hasEntered = false;
    int nShots = 0;
    GameObject Aimed;
    EnemyProperties enemyProp;

    public AimedStateAttack(AimedFSM _FSM)
    {
        m_AimedFSM = _FSM;
    }

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Aimed = GameObject.Find("Aimed");
            enemyProp = Aimed.GetComponent<EnemyProperties>();
            int nAmmo = enemyProp.getAmmo();
        }
        Execute();
    }

    public override void Execute()
    {
        if (nShots > 0) //If ammo is more than 0, the enemy will continue shooting and use ammo.
        {
            Debug.Log("Shoot");
            enemyProp.UseAmmo();
        }

        else
        {
            Exit(); //Once it is empty, exit.
        }
    }

    public override void Exit()
    {
        m_AimedFSM.ChangeState(m_AimedFSM.ReturnNextState());
    }

}
