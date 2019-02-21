using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition<T>
{
    public T m_owner;
    public Transition(T owner)
    {
        m_owner = owner;
    }

    public abstract bool Test();
}
