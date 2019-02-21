using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState<T> : State<T> where T : StateAgent
{
	public AttackState(T owner)
	{
		m_owner = owner;
	}

	public override void Enter()
	{
		m_owner.gameObject.GetComponent<AudioSource>().Play();
		Debug.Log("enter attack");
	}

	public override void Update()
	{
		if (m_owner.target != null)
		{
			Vector3 direction = m_owner.target.transform.position - m_owner.transform.position;
			Quaternion rotation = Quaternion.Lerp(m_owner.transform.rotation, Quaternion.LookRotation(direction, Vector3.up), 15.0f * Time.deltaTime);
			m_owner.rb.MoveRotation(rotation);
			m_owner.rb.velocity = m_owner.transform.forward * 4.0f;
		}

		m_owner.target = m_owner.perception.GetGameObjectWithTag("Player");
		if (m_owner.target == null)
		{
			m_owner.stateMachine.SetState("Patrol");
		}
	}

	public override void Exit()
	{
		Debug.Log("exit attack");
	}
}
