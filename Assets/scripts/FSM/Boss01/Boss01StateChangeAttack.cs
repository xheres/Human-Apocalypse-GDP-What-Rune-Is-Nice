using UnityEngine;
using System.Collections;

public class Boss01StateChangeAttack : Boss01State {

	// Use this for initialization
    bool hasEntered = false;

    [SerializeField]
    
    GameObject chosenMuzzle;
    Boss01FSM Boss;
      public Boss01StateChangeAttack(Boss01FSM _FSM)
	{
		m_BossFSM = _FSM;
	}

      public override void Enter()
      {
          if (hasEntered == false)
          {
              Boss = GameObject.Find("Boss01").GetComponent<Boss01FSM>();
          }
          Debug.Log("executed changeattack");
          Execute();
      }

      public override void Execute()
      {
          chosenMuzzle = Boss.Muzzles[Random.Range(0,Boss.Muzzles.Length)];
          Boss.muzzle = chosenMuzzle;
          Exit();
          
      }

      public override void Exit()
      {
          m_BossFSM.ChangeState(m_BossFSM.ReturnNextState());
      }

}
