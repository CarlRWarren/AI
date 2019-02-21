using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	[SerializeField] Waypoint m_nextWaypoint = null;

	public Waypoint nextWaypoint { get { return m_nextWaypoint; } set { m_nextWaypoint = value; } }

	private void OnTriggerEnter(Collider other)
	{
		SearchAgent searchAgent = other.GetComponent<SearchAgent>();
		//SearchAgent agent = other.GetComponent<SearchAgent>();
		if (searchAgent && (searchAgent.waypoint == this || searchAgent.waypoint == null))
		{
			searchAgent.waypoint = m_nextWaypoint;
		}

        StateAgent stateAgent = other.GetComponent<StateAgent>();
        //SearchAgent agent = other.GetComponent<SearchAgent>();
        if (stateAgent && (stateAgent.waypoint == this || stateAgent.waypoint == null))
        {
            stateAgent.waypoint = m_nextWaypoint;
        }
    }
}
