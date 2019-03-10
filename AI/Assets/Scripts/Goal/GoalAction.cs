using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAction : MonoBehaviour
{
    [SerializeField] Transform m_location = null;
    [SerializeField] Transform m_actionLocation = null;
    [SerializeField] string m_actionName = "";
    [SerializeField] string m_animationName = "";
    [SerializeField] float m_time = 0.0f;

    [SerializeField] GoalResult[] m_results = null;

    public Transform location { get { return m_location; } }
    public Transform actionLocation { get { return m_actionLocation; } }
    public string actionName { get { return m_actionName; } }
    public string animationName { get { return m_animationName; } }
    public float time { get { return m_time; } }

    public GoalResult[] results { get { return m_results; } }

    public float GetResultsChange(GoalNeed need)
    {
        float change = 0.0f;
        foreach(var result in results)
        {
            if(result.type == need.type)
            {
                change = result.value;
            }
        }
        return change;
    }

    public bool HasResultType(GoalNeed.eType type)
    {
        bool hasType = false;
        foreach(var result in results)
        {
            if (result.type == type)
            {
                hasType = true;
                break;
            }
        }
        return hasType;
    }
}
