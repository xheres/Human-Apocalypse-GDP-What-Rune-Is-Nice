//Ong Say Guan, 1401727A

using UnityEngine;
using System.Collections;

public class Boss03Move : Boss03State
{
	bool enteredField = false;
	Boss03State nextState;
	[SerializeField] Vector2[] waypoints;
	Transform BossTransform;
	
	public Boss03Move(Boss03FSM FSM)
	{
		m_Boss03FSM = FSM;
	}
	
	public override void Enter()
	{
		if(!enteredField)
		{
			BossTransform = m_Boss03FSM.transform;
			nextState = new Boss03Fire(m_Boss03FSM);
			enteredField = true;
		}
		Execute();
	}
	
	public override void Execute()
	{
		Vector3.Lerp(BossTransform.position, waypoints[m_Boss03FSM.getMoveId()], 15 * Time.deltaTime);
	}
	
	public override void Exit()
	{
		m_Boss03FSM.NextState(nextState);
	}
}
