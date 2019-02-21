using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecisionNode : DecisionTreeNode
{
    public DecisionTreeNode m_trueNode;
    public DecisionTreeNode m_falseNode;
    public override DecisionTreeNode Execute()
    {
        isActive = true;
        DecisionTreeNode node = GetDecisionNode();
        return (node) ? node.Execute() : null;
    }

    public abstract DecisionTreeNode GetDecisionNode();
}
