using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sequence : Composite
{
    protected override eStatus OnUpdate()
    {
        while (true)
        {
			// check current task
            eStatus status = m_current.Execute();
            if (status != eStatus.SUCCESS)
            {
                return status;
            }
			// if current task is successfully, go to the next task
            m_index++;
			// if done with the sequence (all tasks succeeded), return SUCCESS status
			if (m_index == m_children.Count)
            {
                return eStatus.SUCCESS;
            }
			// set the current task
            m_current = m_children[m_index];
        }
    }
}
