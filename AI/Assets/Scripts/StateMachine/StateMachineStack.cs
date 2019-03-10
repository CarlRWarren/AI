using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineStack<T> : StateMachineBase<T>
{
	Dictionary<string, State<T>> m_states = new Dictionary<string, State<T>>();
	Stack<State<T>> m_statesStack = new Stack<State<T>>();

	public override void Update()
	{
		// check state transition
		State<T> state = m_statesStack.Peek();
		if (state != null)
		{
			foreach (Pair<Transition, string> transition in state.m_transitions)
			{
				if (transition.first.Test())
				{
					string id = transition.second;
					if (id == "") PopState();
					else PushState(id);
					break;
				}
			}
		}

		// update current state
		state = m_statesStack.Peek();
		if (state != null)
		{
			state.Update();
		}
	}

	public override void AddState(State<T> state)
	{
		m_states[state.m_id] = state;
	}

	public override State<T> GetState()
	{
		return m_statesStack.Peek();
	}

	public void PushState(string id)
	{
		Debug.Assert(m_states.ContainsKey(id), id + " state id not found.");
		
		if (m_states.TryGetValue(id, out State<T> newState))
		{
			// pause current state
			State<T> state = m_statesStack.Peek();
			if (state != null)
			{
				state.Pause();
			}

			// start new state
			newState.Enter();
			newState.Update();

			// push new state
			m_statesStack.Push(newState);
		}
	}

	public void PopState()
	{
		State<T> state = m_statesStack.Peek();
		if (state != null)
		{
			// exit/pop current state
			state.Exit();
			m_statesStack.Pop();

			// resume new state
			State<T> newState = m_statesStack.Peek();
			if (newState != null)
			{
				newState.Resume();
				newState.Update();
			}
		}
	}

	public override void SetState(string id)
	{
		Debug.Assert(m_states.ContainsKey(id), id + " state id not found.");

		if (m_states.TryGetValue(id, out State<T> newState))
		{
			State<T> state = m_statesStack.Peek();
			if (newState != state)
			{
				// exit/pop state
				if (state != null)
				{
					state.Exit();
					m_statesStack.Pop();
				}

				// enter/push new state
				newState.Enter();
				newState.Update();
				m_statesStack.Push(newState);
			}
		}
	}
}
