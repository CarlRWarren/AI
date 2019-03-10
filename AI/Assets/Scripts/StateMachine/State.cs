using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
	public T m_owner;
    public string m_id;

    public List<Pair<Transition, string>> m_transitions = new List<Pair<Transition, string>>();

	abstract public void Enter();
	abstract public void Update();
	abstract public void Exit();
    public virtual void Pause()
    {

    }
    public virtual void Resume()
    {

    }
    public void AddTransition(Transition transition, string id)
    {
        Pair<Transition, string> transitionPair = new Pair<Transition, string>();
        transitionPair.first = transition;
        transitionPair.second = id;
        m_transitions.Add(transitionPair);
    }
}
	