using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : Task
{
    protected override eStatus OnUpdate()
    {
		return m_status;
	}
}


