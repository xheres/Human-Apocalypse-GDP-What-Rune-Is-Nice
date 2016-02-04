//Ong Say Guan, 1401727A

using UnityEngine;
using System.Collections;

public abstract class Boss03State
{
	protected Boss03FSM m_Boss03FSM;
	
	public abstract void Enter();
	public abstract void Execute();
	public abstract void Exit();
}
