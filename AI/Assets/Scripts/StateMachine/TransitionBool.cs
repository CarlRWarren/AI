using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBool<T> : Transition<T>
{
    BoolRef m_value;
    bool m_condition;
    public TransitionBool(T owner, ref BoolRef value1, bool condition = true) : base(owner)
    {
        m_value = value1;
        m_condition = condition;
    }

    public override bool Test()
    {
        bool transition = (m_value.m_value == m_condition);
        return transition;
    }
}
