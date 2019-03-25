using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    protected override eStatus OnUpdate()
    {
        while (true)
        {
			// check current task
            eStatus status = m_current.Execute();
            if (status != eStatus.FAIL)
            {
                return status;
            }
			// go to the next task
            m_index++;
			// if done with the sequence (all tasks failed), return FAIL status
			if (m_index == m_children.Count)
            {
                return eStatus.FAIL;
            }
			// set the current task
			m_current = m_children[m_index];
        }
    }
}

