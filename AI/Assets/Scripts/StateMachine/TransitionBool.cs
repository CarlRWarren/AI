using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBool : Transition
{
    BoolRef m_value;
    bool m_condition;
    public TransitionBool(ref BoolRef value1, bool condition = true)
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
