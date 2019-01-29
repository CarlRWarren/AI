using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchNodeSelector : MonoBehaviour
{
	[SerializeField] Node m_source = null;
	[SerializeField] Node m_destination = null;
	[SerializeField] SearchAgent m_agent = null;

	void Update()
	{
		// select source / destination nodes
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				Node node = raycastHit.collider.gameObject.GetComponent<Node>();
				if (node)
				{
					if (m_source == null)
					{
						node.type = Node.eType.SOURCE;
						m_source = node;
					}
					else if (m_destination == null)
					{
						node.type = Node.eType.DESTINATION;
						m_destination = node;

                        // build path
                        SearchDFS.Build(m_source, m_destination, out List<Node> path);
                        m_agent.waypoint = path[0].GetComponentInChildren<Waypoint>();

                        for(int i = 0; i<path.Count-1; i++)
                        { 
                           Waypoint waypoint = path[i].GetComponentInChildren<Waypoint>();
                           waypoint.nextWaypoint = path[i + 1].GetComponentInChildren<Waypoint>();
                        }

                        foreach (Node pathNode in path)
                        {
                            if (pathNode.type == Node.eType.STANDARD)
                            {
                                pathNode.type = Node.eType.PATH;
                            }
                        }
                    }
				}
			}
		}

		// reset nodes
		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_source = null;
			m_destination = null;

			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
			foreach (GameObject go in gameObjects)
			{
				Node node = go.GetComponent<Node>();
				if (node)
				{
					node.type = Node.eType.STANDARD;
					node.visited = false;
				}
			}
		}
	}
}
