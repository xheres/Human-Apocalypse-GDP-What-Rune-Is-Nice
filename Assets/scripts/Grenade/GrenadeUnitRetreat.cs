using UnityEngine;
using System.Collections;

public class GrenadeUnitStateRetreat : GrenadeUnitState {

	bool hasEntered = false;
	GrenadeUnitState nextState;

	public GrenadeUnitStateRetreat(GrenadeUnitFSM _FSM)
	{
		m_GrenadeUnitFSM = _FSM;
	}
	
	public override void Enter()
	{
		if (hasEntered == false) 
		{
			nextState = new GrenadeUnitStateDeleteUnit(m_GrenadeUnitFSM);
		}
	}
	
	public override void Execute()
	{
		Debug.Log("Retreat");
	}
	
	public override void Exit()
	{
		m_GrenadeUnitFSM.ChangeState(nextState);
	}
}
