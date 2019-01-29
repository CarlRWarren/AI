using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SearchNodeCreator : MonoBehaviour
{
	[SerializeField] Node m_node = null;
	[SerializeField] [Range(1, 30)] int m_numNodes = 1;
	[SerializeField] [Range(1.0f, 50.0f)] float m_nodeRange = 1.0f;

	void Start()
    {
		CreateNodes();
		LinkNodes();
	}

	void CreateNodes()
	{
		BoxCollider collider = GetComponent<BoxCollider>();
		Bounds bounds = collider.bounds;

		for (int i = 0; i < m_numNodes; i++)
		{
			Vector3 position = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
			Instantiate(m_node, position, Quaternion.identity, transform);
		}
	}

	void LinkNodes()
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");
		foreach(GameObject go in gameObjects)
		{
			Node node = go.GetComponent<Node>();
			if (node)
			{
				bool connected = false;
				Collider[] colliders = Physics.OverlapSphere(go.transform.position, m_nodeRange);
				foreach (Collider collider in colliders)
				{
					Node otherNode = collider.GetComponent<Node>();
					if (otherNode && otherNode != node)
					{
						Node.Edge edge;
						edge.nodeA = node;
						edge.nodeB = otherNode;

						node.edges.Add(edge);
						connected = true;
					}
				}

				if (connected == false)
				{
					GameObject nearestGameObject = AutonomousAgent.GetNearestGameObject(node.gameObject, "Node");
					Node otherNode = nearestGameObject.GetComponent<Node>();
					if (otherNode)
					{
						Node.Edge edge;
						edge.nodeA = node;
						edge.nodeB = otherNode;

						node.edges.Add(edge);
						connected = true;
					}
				}
			}
		}
	}
}
