using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
	public T m_owner;

    public List<Pair<Transition<T>, string>> m_transitions = new List<Pair<Transition<T>, string>>();

	abstract public void Enter();
	abstract public void Update();
	abstract public void Exit();

    public void AddTransition(Transition<T> transition, string id)
    {
        Pair<Transition<T>, string> transitionPair = new Pair<Transition<T>, string>();
        transitionPair.first = transition;
        transitionPair.second = id;
        m_transitions.Add(transitionPair);
    }
}
	