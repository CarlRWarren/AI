using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeState<T> : State<T> where T : StateAgent
{
    BoolRef m_foundPlayer = new BoolRef(false);
    BoolRef m_search = new BoolRef(false);

    public RechargeState(T owner, string id)
	{
		m_owner = owner;
        m_id = id;
	}

	public override void Enter()
	{
		Debug.Log("enter recharge");
        Transition transition = new TransitionBool(ref m_foundPlayer);
        AddTransition(transition, "Attack");
        transition = new TransitionFloat(ref m_owner.m_energy, 5.0f, TransitionFloat.eCompare.GREATER);
        AddTransition(transition, "Patrol");

    }

    public override void Update()
	{
        m_owner.m_energy.m_value += Time.deltaTime * 2.0f;

        m_owner.target = m_owner.perception.GetGameObjectWithTag("Player");
        m_foundPlayer.m_value = (m_owner.target != null);
    }

	public override void Exit()
	{
		Debug.Log("exit recharge");
	}
}
