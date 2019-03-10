using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState<T> : State<T> where T : StateAgent
{
	public DeathState(T owner, string id)
	{
		m_owner = owner;
        m_id = id;
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
