//Ong Say Guan, 1401727A

using UnityEngine;
using System.Collections;

public class Boss03Fire : Boss03State
{
	bool hasEntered = false;
	Boss03State nextState;
	GameObject muzzleCreator;
	Transform BossTransform;
	
	public Boss03Fire(Boss03FSM FSM)
	{
		m_Boss03FSM = FSM;
	}
	
	public override void Enter()
	{
		if(!hasEntered)
		{
			BossTransform = m_Boss03FSM.transform;
		}
		Execute();
	}
	
	public override void Execute()
	{
		if(m_Boss03FSM.getCanFire())
		{   
			MonoBehaviour.Instantiate(muzzleCreator, BossTransform.position, Quaternion.identity);
			m_Boss03FSM.FireCD();
		}
	}
	
	public override void Exit()
	{
		m_Boss03FSM.NextState(nextState);
	}
}