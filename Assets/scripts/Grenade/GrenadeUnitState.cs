//Ong Say Guan 1401727A P01

using UnityEngine;
using System.Collections;

public abstract class GrenadeUnitState
{
	protected GrenadeUnitFSM m_GrenadeUnitFSM;
	
	public abstract void Enter();
	public abstract void Execute();
	public abstract void Exit();
}
