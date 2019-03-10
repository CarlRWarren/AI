using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionEnum : DecisionNode
{
	public enum eState
	{
		NONE,
		ANGRY,
		SAD,
		HAPPY
	}

	[SerializeField] eState m_value = eState.NONE;
	[SerializeField] eState m_condition = eState.NONE;

	public override DecisionTreeNode GetDecisionNode()
	{
		return (m_value == m_condition) ? m_trueNode : m_falseNode;
	}
}
