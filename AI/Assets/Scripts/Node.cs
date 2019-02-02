using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public enum eType
	{
		STANDARD,
		SOURCE,
		DESTINATION,
		PATH
	}

	public struct Edge
	{
		public Node nodeA;
		public Node nodeB;
	}
	
	public List<Edge> edges = new List<Edge>();
	public eType type { get; set; } = eType.STANDARD;
	public bool visited { get; set; } = false;
    public Node parentNode { get; set; } = null;
    public float cost { get; set; } = float.MaxValue;

	Color[] typeColors = { Color.yellow, Color.green, Color.red, Color.white };

	void Update()
    {
		foreach (Edge edge in edges)
		{
			Debug.DrawLine(edge.nodeA.transform.position, edge.nodeB.transform.position, Color.red);
		}
		GetComponent<Renderer>().material.SetColor("_Color", typeColors[(int)type]);
	}
}
