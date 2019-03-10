using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionRandom : DecisionNode
{
    [SerializeField] DecisionAgent m_agent = null;
    bool m_value = true;
    int m_frame = 0;
    public override DecisionTreeNode GetDecisionNode()
    {
        if(m_frame + 1 != m_agent.frame)
        {
            m_value = (Random.value >= 0.5f);
        }
        m_frame = m_agent.frame;

        return (m_value) ? m_trueNode : m_falseNode;
    }
    
}
