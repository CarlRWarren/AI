using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionInt : Transition
{
    public enum eCompare
    {
        EQUAL,
        GREATER,
        LESS
    }
    IntRef m_value;
    int m_condition;
    eCompare m_compare;
    public TransitionInt(ref IntRef value1, int condition, eCompare compare)
    {
        m_value = value1;
        m_condition = condition;
        m_compare = compare;
    }

    public override bool Test()
    {
        bool transition = false;
        switch (m_compare)
        {
            case eCompare.EQUAL:
                transition = (m_value.m_value == m_condition);
                break;
            case eCompare.GREATER:
                transition = (m_value.m_value > m_condition);
                break;
            case eCompare.LESS:
                transition = (m_value.m_value < m_condition);
                break;
            default:
                break;
        }
        return transition;
    }
}
