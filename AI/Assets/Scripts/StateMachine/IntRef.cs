using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntRef : VarRef<int>
{
    public IntRef()
    {

    }
    public IntRef(int v) { m_value = v; }
}
