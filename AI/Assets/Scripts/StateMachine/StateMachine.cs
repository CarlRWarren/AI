using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> : StateMachineBase<T>
{
	Dictionary<string, State<T>> m_states = new Dictionary<string, State<T>>();
	State<T> m_state = null;

	public override void Update()
	{
		if (m_state != null)
		{
			foreach (Pair<Transition, string> transition in m_state.m_transitions)
			{
				if (transition.first.Test())
				{
					SetState(transition.second);
					break;
				}
			}

			m_state.Update();
		}
	}

	public override void AddState(State<T> state)
	{
		m_states[state.m_id] = state;
	}

	public override State<T> GetState()
	{
		return m_state;
	}

	public override void SetState(string id)
	{
		Debug.Assert(m_states.ContainsKey(id), id + " state id not found.");

		if (m_states.TryGetValue(id, out State<T> state))
		{
			if (state != m_state)
			{
				if (m_state != null)
				{
					m_state.Exit();
				}
				m_state = state;
				m_state.Enter();
				m_state.Update();
			}
		}
	}
}
