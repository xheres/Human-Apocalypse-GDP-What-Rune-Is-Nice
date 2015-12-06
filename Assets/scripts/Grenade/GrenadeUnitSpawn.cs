//Ong Say Guan 1401727A P01

using UnityEngine;
using System.Collections;

public class GrenadeUnitStateSpawn : GrenadeUnitState {
	bool hasEntered = false;
	GrenadeUnitState nextState;

	public GrenadeUnitStateSpawn(GrenadeUnitFSM _FSM)
	{
		m_GrenadeUnitFSM = _FSM;
	}
	
	public override void Enter()
	{
		if(!hasEntered)
		{
			nextState = new GrenadeUnitStateCreateMuzzle(m_GrenadeUnitFSM);
			hasEntered = true;
		}

		if (hasEntered == false)
		{
			Execute();
			hasEntered = true;
		}
	}
	
	public override void Execute()
	{
		//spawn GrenadeUnit
		Debug.Log("Grenade Unit Spawned");
		//Call Exit
		Exit();
	}
	
	public override void Exit()
	{
		m_GrenadeUnitFSM.ChangeState(nextState);
	}
}
