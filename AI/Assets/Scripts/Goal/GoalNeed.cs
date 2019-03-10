using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalNeed : MonoBehaviour
{
    public enum eType
    {
        NONE,
        HUNGER,
        COMFORT,
        HYGIENE,
        BLADDER,
        ENERGY,
        FUN,
        SOCIAL,
        ROOM
    }

    [SerializeField] eType m_type = eType.NONE;
    [SerializeField] AnimationCurve m_weight = null;
    [SerializeField] float m_value = 1.0f;
    [SerializeField] float m_decay = 0.0f;

    public eType type { get { return m_type; } }
    public float value { get { return m_value; } set { m_value = value; } }
    public float mood { get { return m_weight.Evaluate(value) * value; } }

    void Update()
    {
        value -= m_decay * Time.deltaTime;
        value = Mathf.Clamp(value,-1.0f,1.0f);
    }

    public float GetMood(float _value)
    {
        return m_weight.Evaluate(_value) * _value;
    }
}
