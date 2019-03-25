using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterFloat : Parameter
{
    [SerializeField] float m_value;
    
    public float value { get { return m_value; } set { m_value = value; } }
}
