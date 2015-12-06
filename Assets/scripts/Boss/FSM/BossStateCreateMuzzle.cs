//Matric Number: 1401169f, Name: Calvin, Class: P01
using UnityEngine;
using System.Collections;

public class BossStateCreateMuzzle : BossState {

   
    [SerializeField] GameObject[] muzzles = new GameObject[3];
    GameObject prevMuzzle;
    GameObject chosenMuzzle;
    GameObject Boss;
    EnemyProperties enemyProp;

    bool hasEntered = false;

    public BossStateCreateMuzzle(BossFSM _FSM)
	{
		m_BossFSM = _FSM;
	}

    public override void Enter()
    {
        if (hasEntered == false)
        {
            Boss = GameObject.Find("Boss_1");
            enemyProp = Boss.GetComponent<EnemyProperties>();
            hasEntered = true;
        }
        Execute();
    }

    public override void Execute()
    {
        int i = Random.Range(0, 3); //random a number between 0-2
        chosenMuzzle = muzzles[i];
        while (chosenMuzzle == prevMuzzle) //as long as the chosen muzzle is the same as the prev muzzle, do a random between 0-2 again 
        {
            i = Random.Range(0, 3); //random a number between 0-2
            chosenMuzzle = muzzles[i];
        }
        enemyProp.setMuzzle(chosenMuzzle);
        Debug.Log("Create the muzzle");
        Exit();
    }

    public override void Exit()
    {
        m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
    }
}
