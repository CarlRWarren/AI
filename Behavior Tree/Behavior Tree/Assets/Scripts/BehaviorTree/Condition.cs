using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : Task
{
	protected override eStatus OnUpdate()
	{
		return m_status;
	}
}



