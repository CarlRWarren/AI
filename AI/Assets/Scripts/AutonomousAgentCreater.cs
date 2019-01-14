using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousAgentCreater : MonoBehaviour
{
    [SerializeField] AutonomousAgent[] m_agents = null;
    int m_agentIndex = 0;

    void Update()
    {
        for (int i = 0; i < m_agents.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) m_agentIndex = i;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                Instantiate(m_agents[m_agentIndex], hit.point, Quaternion.identity);
            }
        }
    }
}
