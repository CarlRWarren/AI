using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterInt : Parameter
{
    [SerializeField] int m_value;
    
    public int value { get { return m_value; } set { m_value = value; } }
}
