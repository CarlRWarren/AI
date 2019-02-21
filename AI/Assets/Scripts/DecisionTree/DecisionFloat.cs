using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionFloat : DecisionNode
{
    public enum eCompare
    {
        EQUAL,
        GREATER,
        LESS
    }
    [SerializeField] float m_value = 0.0f;
    [SerializeField] float m_condition = 0.0f;
    [SerializeField] eCompare m_compare = eCompare.EQUAL;
    public override DecisionTreeNode GetDecisionNode()
    {
        bool isTrue = false;
        switch (m_compare)
        {
            case eCompare.EQUAL:
                isTrue = (m_value == m_condition);
                break;
            case eCompare.GREATER:
                isTrue = (m_value > m_condition);
                break;
            case eCompare.LESS:
                isTrue = (m_value < m_condition);
                break;
            default:
                break;
        }
        return (isTrue) ? m_trueNode : m_falseNode;
    }
    
}
