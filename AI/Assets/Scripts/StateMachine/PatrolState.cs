using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState<T> : State<T> where T : StateAgent
{
	public PatrolState(T owner)
	{
		m_owner = owner;
	}

	public override void Enter()
	{
		Debug.Log("enter patrol");
	}
	
	public override void Update()
	{
		if (m_owner.waypoint != null)
		{
			Vector3 direction = m_owner.waypoint.transform.position - m_owner.transform.position;
			Quaternion rotation = Quaternion.Lerp(m_owner.transform.rotation, Quaternion.LookRotation(direction, Vector3.up), 15.0f * Time.deltaTime);
			m_owner.rb.MoveRotation(rotation);
			m_owner.rb.velocity = m_owner.transform.forward * 4.0f;
		}

		m_owner.target = m_owner.perception.GetGameObjectWithTag("Player");
		if (m_owner.target)
		{
			m_owner.stateMachine.SetState("Attack");
		}
	}
	
	public override void Exit()
	{
		Debug.Log("exit patrol");
	}
}
