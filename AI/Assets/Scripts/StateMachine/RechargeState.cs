using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeState<T> : State<T> where T : StateAgent
{
	public RechargeState(T owner)
	{
		m_owner = owner;
	}

	public override void Enter()
	{
		Debug.Log("enter recharge");
	}

	public override void Update()
	{
        m_owner.m_energy.m_value += Time.deltaTime * 2.0f;
        Debug.Log("energy: " + m_owner.m_energy.m_value);

        if(m_owner.m_energy.m_value >= 5.0f)
        {
            m_owner.stateMachine.SetState("Patrol");
        }
	}

	public override void Exit()
	{
		Debug.Log("exit recharge");
	}
}
