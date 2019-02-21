using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState<T> : State<T> where T : StateAgent
{
	public DeathState(T owner)
	{
		m_owner = owner;
	}

	public override void Enter()
	{
		Debug.Log("enter death");
	}

	public override void Update()
	{
		
	}

	public override void Exit()
	{
		Debug.Log("exit deathe");
	}
}
