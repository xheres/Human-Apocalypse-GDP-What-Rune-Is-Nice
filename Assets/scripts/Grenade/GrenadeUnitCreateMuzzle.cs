using UnityEngine;
using System.Collections;

public class GrenadeUnitStateCreateMuzzle : GrenadeUnitState {

	bool hasEntered = false;
	GrenadeUnitState nextState;

	public GrenadeUnitStateCreateMuzzle(GrenadeUnitFSM _FSM)
	{
		m_GrenadeUnitFSM = _FSM;
	}
	
	public override void Enter()
	{
		if(!hasEntered)
		{
			nextState = new GrenadeUnitStateAttack(m_GrenadeUnitFSM);
			hasEntered = true;
		}

		Execute();
	}
	
	public override void Execute()
	{
		Debug.Log("Create the muzzle");
	}
	
	public override void Exit()
	{
		m_GrenadeUnitFSM.ChangeState(nextState);
	}
}
