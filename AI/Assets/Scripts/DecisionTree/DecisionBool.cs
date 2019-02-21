using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionBool : DecisionNode
{
    [SerializeField] bool m_value = true;
    public override DecisionTreeNode GetDecisionNode()
    {
        return (m_value) ? m_trueNode : m_falseNode;
    }
    
}
