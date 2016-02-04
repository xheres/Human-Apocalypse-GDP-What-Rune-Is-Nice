//Ong Say Guan, 1401727A

using UnityEngine;
using System.Collections;

public class Boss03FSM : MonoBehaviour 
{
	Boss03State nextState;
	DistanceController distCont;
	bool bossSpawned = false;
	int attackId;
	int moveId;
	bool canFire;
	float[] cd = {};
	
	public void NextState(Boss03State state)
	{
		nextState = state;
	}
	
	public bool getCanFire()
	{
		return canFire;
	}
	
	public void setCanFire(bool fire)
	{
		canFire = fire;
	}
	
	public void FireCD()
	{
		Invoke("allowFire", cd[attackId]);
	}
	
	void allowFire()
	{
		canFire = true;
	}
	
	public int getMoveId()
	{
		return moveId;
	}
	public int getAttackId()
	{
		return attackId;
	}
	
	public void setMoveId(int id_move)
	{
		moveId = id_move;
	}
	
	public void setAttackIndex(int id_attack)
	{
		attackId = id_attack;
	}
	
	void Start()
	{
		nextState = new Boss03Spawn(this);
		distCont = GameObject.Find("_DistanceController").GetComponent<DistanceController>();
	}
	
	void Update()
	{
		if(distCont.checkBossStage() && !bossSpawned)
		{
			nextState.Enter();
			bossSpawned = true;
		}
	}
}
