using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
	Dictionary<string, State<T>> m_states = new Dictionary<string, State<T>>();
	State<T> m_state = null;
    Stack<State<T>> m_stateStack = new Stack<State<T>>();

	public void Update()
	{
        m_state = m_stateStack.Peek();
		if (m_state != null)
		{
            foreach(var transition in m_state.m_transitions)
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

	public void AddState(string id, State<T> state)
	{
		m_states[id] = state;
	}

    public void PushState(string id)
    {
        var state = m_stateStack.Peek();
        if (state != null)
        {
            state.Exit();
        }
            if (m_states.TryGetValue(id, out State<T> nextstate))//var state = m_states[id];
        {
            nextstate.Enter();
            m_stateStack.Push(nextstate);
        } 
    }

    public void PopState()
    {
        var state = m_stateStack.Peek();
        if (state != null)
        {
            state.Exit();
            m_stateStack.Pop();
        }
        state = m_stateStack.Peek();
        if (state != null)
        {
            state.Enter();
        }
    }

	public void SetState(string id)
	{
        Debug.Assert(m_states.ContainsKey(id), "State not found: " + id);
		if (m_states.ContainsKey(id))//if(m_states.TryGetValue(id, out State<T> state))
        {
			State<T> state = m_states[id];
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
