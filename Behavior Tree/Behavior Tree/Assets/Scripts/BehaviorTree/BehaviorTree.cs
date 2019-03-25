using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaviorTree : MonoBehaviour
{
    Task[] m_tasks;

    void Start()
    {
        m_tasks = GetComponentsInChildren<Task>();
    }

    void Update()
    {
		// reset all the tasks
		foreach (Task task in m_tasks)
		{
			task.UpdateStatusUI(true);
		}
	}
}

