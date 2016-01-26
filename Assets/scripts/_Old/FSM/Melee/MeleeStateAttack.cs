// Lucas Lim 
// P01 
// 1402476D

using UnityEngine;
using System.Collections;

public class MeleeStateAttack : MeleeState {

    EnemyProperties enemyProp;

    bool attack = false;
    bool hit = false;

    int charge = 0;
    int chargeCounter;
    GameObject melee;
    MeleeState nextState;

    

    public MeleeStateAttack(MeleeFSM _FSM)
    {
        m_MeleeFSM = _FSM;
    }

    public override void Enter()
    {
        if (!attack)
        {
            // count the number of times the melee mob attacks
            chargeCounter = charge;
            enemyProp = melee.GetComponent<EnemyProperties>();
            int nAmmo = enemyProp.getAmmo();

            if (chargeCounter < 20)
            {

                // transform.position something something
                // make the enemy dash forward towards the player in a straight line

                if (!hit)
                {
                    nextState = new MeleeStateReturn(m_MeleeFSM);
                    attack = true;
                }
                else
                {
                    nextState = new MeleeStateExplode(m_MeleeFSM);

                    attack = true;
                }
            }
            else
            {
                nextState = new MeleeStateRetreat(m_MeleeFSM);
            }
        }

        Execute();
    }

    public override void Execute()
    {
        if (chargeCounter < 20)
        {
            chargeCounter++;
            enemyProp.UseAmmo();
        }
    }

    public override void Exit()
    {
        m_MeleeFSM.ChangeState(nextState);
    }

}
