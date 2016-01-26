//Name: Jared Koh
//Admin No: 1402535G
//Class: P01

using UnityEngine;
using System.Collections;

public class AimedStateCreateMuzzle : AimedState {

    GameObject muzzle;
    GameObject Aimed;
    EnemyProperties enemyProp;

    bool hasEntered = false;

    public AimedStateCreateMuzzle(AimedFSM _FSM)
    {
        m_AimedFSM = _FSM;
    }

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Aimed = GameObject.Find("Aimed");
            enemyProp = Aimed.GetComponent<EnemyProperties>();
        }
        Execute();
    }

    public override void Execute()
    {
        enemyProp.setMuzzle(muzzle); //set the current muzzle to gameobject muzzle
        Debug.Log("Muzzle created.");
    }

    public override void Exit()
    {
        m_AimedFSM.ChangeState(m_AimedFSM.ReturnNextState());
    }
}
