using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : Task
{
    protected Task m_current = null;
    protected int m_index = 0;

    protected override void OnInitialize()
    {
        m_index = 0;
        m_current = m_children[m_index];
    }
}
