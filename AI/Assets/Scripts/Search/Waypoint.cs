using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Waypoint m_nextWaypoint = null;

    public Waypoint nextWaypoint { get { return m_nextWaypoint; }  set { m_nextWaypoint = value; } }

    private void OnTriggerEnter(Collider other)
    {
        SearchAgent agent = other.GetComponent<SearchAgent>();
        if(agent && (agent.waypoint == this || agent.waypoint == null))
        {
            agent.waypoint = m_nextWaypoint;
        }
    }
}
