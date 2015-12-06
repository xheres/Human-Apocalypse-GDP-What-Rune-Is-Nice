using UnityEngine;
using System.Collections;

public class GrenadeUnitStateDeleteUnit :GrenadeUnitState {
	
	public GrenadeUnitStateDeleteUnit(GrenadeUnitFSM _FSM)
	{
		m_GrenadeUnitFSM = _FSM;
	}
	
	public override void Enter()
	{
		
	}
	
	public override void Execute()
	{
		Debug.Log("Grenade Unit Deleted");
	}
	
	public override void Exit()
	{
		
	}
}
