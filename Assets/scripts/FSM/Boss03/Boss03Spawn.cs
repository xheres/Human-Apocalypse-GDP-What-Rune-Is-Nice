//Ong Say Guan, 1401727A

using UnityEngine;
using System.Collections;

public class Boss03Spawn : Boss03State
{
	bool enteredField = false;
	[SerializeField] float yPosition = 7.00f;
	[SerializeField] GameObject Boss03;
	Boss03State nextState;
	
	public Boss03Spawn(Boss03FSM FSM)
	{
		m_Boss03FSM = FSM;
	}
	
	public override void Enter()
	{
		if (!enteredField)
		{
			enteredField = true;
		}
		Execute();
	}
	
	public override void Execute()
	{
		MonoBehaviour.Instantiate(Boss03, new Vector3(0, yPosition, 0), Quaternion.identity);
		Exit();
	}
	
	public override void Exit()
	{
		m_Boss03FSM.NextState(nextState);
	}
}