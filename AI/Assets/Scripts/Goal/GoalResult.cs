using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalResult : MonoBehaviour
{
    [SerializeField] GoalNeed.eType m_type = GoalNeed.eType.NONE;
    [SerializeField] [Range(-2.0f, 2.0f)] float m_value = 1.0f;
    public GoalNeed.eType type { get { return m_type; } }
    public float value { get { return m_value; } set { m_value = value; } }
}
