using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineBase<T>
{
	Dictionary<string, State<T>> m_states = new Dictionary<string, State<T>>();

	public abstract void Update();
	public abstract void AddState(State<T> state);
	public abstract State<T> GetState();
	public abstract void SetState(string id);

	//public bool HandleMessage(ref EventData data)
	//{
	//	State<T> state = GetState();
	//	if (state != null)
	//	{
	//		return state.OnMessage(ref data);
	//	}

	//	return false;
	//}
}
