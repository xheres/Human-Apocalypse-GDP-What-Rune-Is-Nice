using UnityEngine;
using System.Collections;

public class GrenadeUnitStateAttack : GrenadeUnitState {
	bool hasEntered = false;
	GrenadeUnitState nextState;
	GameObject GrenadeUnit;
	EnemyProperties enemyP;
	int nAmmo = enemyP.getAmmo();
	[SerializeField] GameObject rocket;
	[SerializeField] GameObject grenade;
	GameObject currentMuzzle;
	
	public GrenadeUnitStateAttack(GrenadeUnitFSM _FSM)
	{
		m_GrenadeUnitFSM = _FSM;
	}
	
	public override void Enter()
	{
		if (hasEntered == false)
		{
			GrenadeUnit = GameObject.Find("GrenadeUnit_1");
			enemyP = GrenadeUnit.GetComponent<EnemyProperties>();
			nextState = new GrenadeUnitStateRetreat(m_GrenadeUnitFSM);
		}


		Execute();
	}
	
	public override void Execute()
	{
		//if player's x position is within -0.5 to +0.5 of GrenadeUnit's x position, create rocket
		//else create grenade

		//shoot based on the muzzle until a certain amount of shots, while reducing maxammo by 1 each time by calling UseAmmo
		if (nAmmo > 0)
		{
			Debug.Log("Throw Grenade!");
			enemyP.UseAmmo();
		}
		else
		{
			Exit();
		}
	}
	
	public override void Exit()
	{
		m_GrenadeUnitFSM.ChangeState(nextState);
	}
}
