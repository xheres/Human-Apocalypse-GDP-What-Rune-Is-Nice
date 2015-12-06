//Ong Say Guan 1401727A P01

using UnityEngine;
using System.Collections;

public class GrenadeUnitFSM : MonoBehaviour 
{
	GrenadeUnitState currentState;
	
	public void ChangeState(GrenadeUnitState state)
	{
		currentState = state;
	}
	
	void Start()
	{
		currentState = new GrenadeUnitStateSpawn(this);
	}
	
	void Update()
	{
		currentState.Enter();
	}
}