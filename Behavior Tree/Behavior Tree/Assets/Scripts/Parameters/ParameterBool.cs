using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterBool : Parameter
{
    [SerializeField] bool m_value;
    
    public bool value { get { return m_value; } set { m_value = value; } }
}
