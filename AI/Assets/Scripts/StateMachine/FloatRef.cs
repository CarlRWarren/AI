using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatRef : VarRef<float>
{
    public FloatRef()
    {

    }
    public FloatRef(float v) { m_value = v; }
}
