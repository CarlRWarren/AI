using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SearchNodeCreator : MonoBehaviour
{
	[SerializeField] Node m_node = null;
	[SerializeField] [Range(1, 50)] int m_numNodes = 25;
	[SerializeField] [Range(1.0f, 500.0f)] float m_nodeRange = 1.0f;
    [SerializeField] Transform m_parent = null;
    [SerializeField] LayerMask m_layerMask;

	void Start()
    {
		CreateNodes();
		LinkNodes();
	}

	public void CreateNodes()
	{
		BoxCollider collider = GetComponent<BoxCollider>();
		Bounds bounds = collider.bounds;

        float xs = bounds.min.x;
        float zs = bounds.min.z;
        float xd = (bounds.max.x - bounds.min.x) / (m_numNodes - 1);
        float zd = (bounds.max.z - bounds.min.z) / (m_numNodes - 1);

        for(int xi=0; xi<m_numNodes; xi++)
        {
            for (int zi = 0; zi < m_numNodes; zi++)
            {
                Vector3 position = new Vector3(xs + (xi * xd), bounds.max.y, zs + (zi * zd));
                if(Physics.Raycast(position, Vector3.down, out RaycastHit hit, (bounds.max.y - bounds.min.y)))
                {
                    if((1 << hit.collider.gameObject.layer & m_layerMask) != 0)
                    {
                        Instantiate(m_node, hit.point + new Vector3(0.0f,1.0f,0.0f), Quaternion.identity, m_parent);
                    }
                }
            }
        }

		//for (int i = 0; i < m_numNodes; i++)
		//{
		//	Vector3 position = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
		//	Instantiate(m_node, position, Quaternion.identity, transform);
		//}
	}

    public void ClearNodes()
    {
        Node[] nodes = m_parent.GetComponentsInChildren<Node>();
        foreach (Node node in nodes)
        {
            DestroyImmediate(node.gameObject);
        }
    }

	public void LinkNodes()
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
