using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionRandomTime : DecisionNode
{
    [SerializeField] [Range(0.0f, 100.0f)] float m_time = 0.0f;
    bool m_value = true;
    float m_timer = 0.0f;
    public override DecisionTreeNode GetDecisionNode()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0.0f)
        {
            m_timer = m_time;
            m_value = Random.value >= 0.5f;
        }
        return (m_value) ? m_trueNode : m_falseNode;
    }
    
}
