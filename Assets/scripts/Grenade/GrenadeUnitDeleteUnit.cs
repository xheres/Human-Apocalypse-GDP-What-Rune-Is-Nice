using UnityEngine;
using System.Collections;

public class GrenadeUnitStateDeleteUnit :GrenadeUnitState {

	bool hasEntered = false;

	public GrenadeUnitStateDeleteUnit(GrenadeUnitFSM _FSM)
	{
		m_GrenadeUnitFSM = _FSM;
	}
	
	public override void Enter()
	{
		if (hasEntered == false)
		{
			Execute();
			hasEntered = true;
		}
	}
	
	public override void Execute()
	{
		Debug.Log("Grenade Unit Deleted");
	}
	
	public override void Exit()
	{
		Debug.Log("Delete Grenade Unit");
	}
}
